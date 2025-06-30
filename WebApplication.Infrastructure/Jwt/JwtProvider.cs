using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using WebApplication.Application.DTOs.Users;
using WebApplication.Application.Interfaces;
using WebApplication.Domain.Entities;

namespace WebApplication.Infrastructure.Jwt
{
    public class JwtProvider(ITokenService tokenService, IConfiguration configuration) : IJwtProvider
    {
        public string CookieName => configuration["JwtOptions:CookieName"] ?? "RefreshToken";
        public TimeSpan RefreshTokenExpiresDays => TimeSpan.FromDays(int.Parse(configuration["JwtOptions:RefreshTokenExpiresDays"] ?? "15"));
        public TimeSpan AccessTokenExpiresMinutes => TimeSpan.FromMinutes(int.Parse(configuration["JwtOptions:AccessTokenExpiresMinutes"] ?? "5"));
        public string Issuer => configuration["JwtOptions:Issuer"] ?? "DefautlIssuer";
        public string Audience => configuration["JwtOptions:Audience"] ?? "DefaultAudience";
        private string? SecretKey => configuration["JwtOptions:SecretKey"];

        public async Task<(string accessToken, string refreshToken)> GenerateTokensAsync(UserIdentity user, CancellationToken cancellationToken = default)
        {
            var accessToken = GenerateAccessToken(user);
            var refreshToken = GenerateRefreshToken();

            await SaveRefreshTokenAsync(user.Id, refreshToken, cancellationToken);
            return (accessToken, refreshToken);
        }

        public async Task RevokeUserTokenAsync(string token, CancellationToken cancellationToken = default)
        {
            var refreshToken = await tokenService.GetActiveTokenAsync(token, cancellationToken);
            if (refreshToken == null) return;
            await tokenService.RevokeTokenAsync(refreshToken, cancellationToken);
        }

        public async Task RevokeAllUserTokensAsync(Guid userId, CancellationToken cancellationToken = default)
        {
            var userTokens = tokenService.GetActiveTokensByUserIdAsync(userId, cancellationToken);
            await foreach (var token in userTokens)
            {
                await tokenService.RevokeTokenAsync(token, cancellationToken);
            }
        }

        public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            if (string.IsNullOrEmpty(SecretKey))
            {
                throw new InvalidOperationException("Отсутсвует секретный ключ для подписи токена");
            }

            return ValidateJwtToken(token, new()
            {
                ValidateIssuer = true,
                ValidIssuer = Issuer,
                ValidateAudience = true,
                ValidAudience = Audience,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey)),
                ValidateLifetime = false
            });
        }

        public async Task<Guid> GetUserIdByRefreshTokenAsync(string token, CancellationToken ct)
        {
            var refreshToken = await tokenService.GetActiveTokenAsync(token, ct);
            return refreshToken is null ? throw new SecurityTokenException("Invalid token") : refreshToken.UserId;
        }

        public async Task<bool> ValidateRefreshToken(string refreshToken, CancellationToken ct)
        {
            var token = await tokenService.GetActiveTokenAsync(refreshToken, ct);
            return token is not null;
        }

        private static ClaimsPrincipal ValidateJwtToken(string accessToken, TokenValidationParameters parameters)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(accessToken, parameters, out SecurityToken securityToken);

            if (securityToken is not JwtSecurityToken jwtSecurityToken ||
                !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new SecurityTokenException("Invalid token");
            }

            return principal;
        }

        private string GenerateAccessToken(UserIdentity user)
        {
            var secretKey = SecretKey;
            if (string.IsNullOrEmpty(secretKey))
            {
                throw new InvalidOperationException("Отсутсвует секретный ключ для подписи токена");
            }

            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Name)
            };

            foreach (var role in user.Roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.Name));
            }

            var token = new JwtSecurityToken(
                issuer: Issuer,
                audience: Audience,
                claims: claims,
                expires: DateTime.UtcNow.Add(AccessTokenExpiresMinutes),
                signingCredentials: signingCredentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private static string GenerateRefreshToken()
        {
            var randomNumber = new byte[64];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);

            return Convert.ToBase64String(randomNumber);
        }

        private async Task SaveRefreshTokenAsync(Guid userId, string token, CancellationToken cancellationToken = default)
        {
            var refreshToken = new RefreshToken
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                Token = token,
                CreatedAt = DateTime.UtcNow,
                ExpiresAt = DateTime.UtcNow.Add(RefreshTokenExpiresDays),
            };

            await tokenService.AddRefreshTokenAsync(refreshToken, cancellationToken);
        }
    }
}

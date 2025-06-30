using System.Runtime.CompilerServices;
using System.Text.Json;
using WebApplication.Application.Interfaces;
using WebApplication.Domain.Entities;

namespace WebApplication.Application.Services
{
    public class TokenService(ICache cache) : ITokenService
    {
        public async Task AddRefreshTokenAsync(RefreshToken refreshToken, CancellationToken ct)
        {
            var expiration = refreshToken.ExpiresAt - DateTime.UtcNow;
            await cache.ObjectSetAsync($"token:{refreshToken.Id}", refreshToken, ct, expiration);
            await cache.StringSetAsync($"tokenId:{refreshToken.Token}", refreshToken.Id.ToString(), ct, expiration);
            await cache.SetAddAsync($"user:{refreshToken.UserId}:tokens", refreshToken.Token, ct, expiration);
        }

        public async Task<RefreshToken?> GetActiveTokenAsync(string userRefreshToken, CancellationToken ct)
        {
            var tokenId = await cache.StringGetAsync($"tokenId:{userRefreshToken}", ct);
            var tokenString = await cache.StringGetAsync($"token:{tokenId}", ct);
            if (string.IsNullOrEmpty(tokenString)) return null;

            return JsonSerializer.Deserialize<RefreshToken>(tokenString);
        }

        public async Task<RefreshToken?> GetActiveTokenByIdAsync(Guid tokenId, CancellationToken ct)
        {
            var tokenString = await cache.StringGetAsync($"token:{tokenId}", ct);
            if (string.IsNullOrEmpty(tokenString)) return null;
            return JsonSerializer.Deserialize<RefreshToken>(tokenString);
        }

        public async Task RevokeTokenAsync(RefreshToken refreshToken, CancellationToken ct)
        {
            await cache.RemoveAsync($"token:{refreshToken.Id}", ct);
            await cache.RemoveAsync($"tokenId:{refreshToken.Token}", ct);
            await cache.SetRemoveAsync($"user:{refreshToken.UserId}:tokens", refreshToken.Token, ct);
        }

        public async IAsyncEnumerable<RefreshToken> GetActiveTokensByUserIdAsync(Guid userId, [EnumeratorCancellation] CancellationToken ct)
        {
            var tokens = await cache.SetGetAsync($"user:{userId}:tokens", ct);
            foreach (var token in tokens)
            {
                ct.ThrowIfCancellationRequested();
                var tokenId = await cache.StringGetAsync($"tokenId:{token}", ct);
                var tokenString = await cache.StringGetAsync($"token:{tokenId}", ct);
                if (string.IsNullOrEmpty(tokenString)) continue;
                var refreshToken = JsonSerializer.Deserialize<RefreshToken>(tokenString);
                if (refreshToken is null) continue;
                yield return refreshToken;
            }
        }


    }
}

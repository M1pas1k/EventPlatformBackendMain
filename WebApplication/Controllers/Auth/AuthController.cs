using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WebApplication.API.Common;
using WebApplication.API.Extensions;
using WebApplication.Application.Common.Results;
using WebApplication.Application.DTOs.Users;
using WebApplication.Application.Features.Auth.Commands;
using WebApplication.Application.Features.Auth.Handlers;
using WebApplication.Application.Features.Auth.Queries;
using WebApplication.Application.Features.Roles.Queries;
using WebApplication.Application.Features.Users.Commands;
using WebApplication.Application.Interfaces;
using WebApplication.Domain.Entities;

namespace WebApplication.API.Controllers.Auth
{
    [ApiController]
    [Route("/api/auth")]
    public class AuthController(IMediator mediator, IJwtProvider jwtProvider, IPasswordHasher passwordHasher, ITokenService tokenService) : ControllerApiBase
    {
        private CookieOptions _cookieOptions => new()
        {
            Path = "/api/auth",
            Expires = DateTime.UtcNow.Add(jwtProvider.RefreshTokenExpiresDays),
            HttpOnly = true,
            SameSite = SameSiteMode.Lax,
            Secure = false,
        };

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto reqwest, CancellationToken ct)
        {
            var refreshToken = Request.Cookies[jwtProvider.CookieName];

            if (!string.IsNullOrEmpty(refreshToken))
            {
                var isTokenValid = await jwtProvider.ValidateRefreshToken(refreshToken, ct);
                if (isTokenValid) return BadRequest("Токен ещё действует");
            }

            Result<UserIdentity> identity = null!;

            if (reqwest.LoginType is LoginType.Username)
            {
                identity = await mediator.Send(new GetIdentityByUsernameQuery() { Username = reqwest.Login }, ct);
            }
            if (reqwest.LoginType is LoginType.Email)
            {
                identity = await mediator.Send(new GetIdentityByEmailQuery() { Email = reqwest.Login }, ct);
            }

            if (identity.IsFailure)
            {
                return ToActionResult(identity);
            }

            var user = identity.Value!;
            var isPasswordEqual = passwordHasher.Verify(reqwest.Password, user.PasswordHash);
            if (!isPasswordEqual)
            {
                return Unauthorized(reqwest.Login);
            }

            var tokens = await jwtProvider.GenerateTokensAsync(user, ct);
            Response.Cookies.Append(jwtProvider.CookieName, tokens.refreshToken, _cookieOptions);

            return Ok(new { AccessToken = tokens.accessToken });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserCreateDto user, CancellationToken ct)
        {
            var result = await mediator.Send(new GetIdentityByEmailQuery() { Email = user.Email }, ct);
            if (result.IsSuccess)
            {
                return Conflict(user.Name);
            }

            var verification = await mediator.Send(new VerifyConfirmationCodeCommand() { Code = user.ConfirmationCode, Email = user.Email }, ct);
            if (verification.IsFailure)
            {
                return ToActionResult(verification);
            }

            var newUser = await mediator.Send(new CreateUserCommand() { Entity = user }, ct);
            if (newUser.IsFailure)
            {
                return ToActionResult(newUser);
            }

            return Created();
        }

        [HttpPost("restore-password")]
        public async Task<IActionResult> RestorePassowrd(string email, string confirmationCode, string newPassword, CancellationToken ct)
        {
            var identity = await mediator.Send(new GetIdentityByEmailQuery() { Email = email }, ct);
            if (identity.IsFailure) return ToActionResult(identity);

            var confirmation = await mediator.Send(new VerifyConfirmationCodeCommand()
            {
                Email = email,
                Code = confirmationCode
            });
            if (confirmation.IsFailure) return ToActionResult(confirmation);

            var change = await mediator.Send(new ChangeUserPasswordCommand() { UserId = identity.Value!.Id, Password = newPassword });
            return ToActionResult(change);
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> RefreshTokens(CancellationToken ct)
        {
            var refreshToken = Request.Cookies[jwtProvider.CookieName];

            if (string.IsNullOrEmpty(refreshToken))
            {
                return Unauthorized("Отсутствует refresh токен");
            }

            Response.Cookies.Delete(jwtProvider.CookieName, _cookieOptions);

            Guid userId;
            try
            {
                userId = await jwtProvider.GetUserIdByRefreshTokenAsync(refreshToken, ct);
            }
            catch (SecurityTokenException ex)
            {
                return Unauthorized(ex.Message);
            }

            var result = await mediator.Send(new GetIdentityByIdQuery() { Id = userId }, ct);

            if (result.IsFailure)
            {
                return NotFound(refreshToken);
            }

            await jwtProvider.RevokeUserTokenAsync(refreshToken, ct);
            var tokens = await jwtProvider.GenerateTokensAsync(result.Value!, ct);

            Response.Cookies.Append(jwtProvider.CookieName, tokens.refreshToken, _cookieOptions);

            return Ok(new { AccessToken = tokens.accessToken });
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout(CancellationToken ct)
        {
            var refreshToken = Request.Cookies[jwtProvider.CookieName];

            if (string.IsNullOrEmpty(refreshToken))
            {
                return Unauthorized("Отсутствует refresh токен");
            }

            await jwtProvider.RevokeUserTokenAsync(refreshToken, ct);
            Response.Cookies.Delete(jwtProvider.CookieName, _cookieOptions);

            return Ok();
        }

        [Authorize]
        [HttpPost("logout/all")]
        public async Task<IActionResult> LogoutFromAll(CancellationToken ct)
        {
            await jwtProvider.RevokeAllUserTokensAsync(User.Id(), ct);
            Response.Cookies.Delete(jwtProvider.CookieName, _cookieOptions);
            return Ok();
        }

        [Authorize]
        [HttpPost("logout/{sessionId}")]
        public async Task<IActionResult> RevokeActiveSession(Guid sessionId, CancellationToken ct)
        {
            var token = await tokenService.GetActiveTokenByIdAsync(sessionId, ct);

            if (token == null)
            {
                return BadRequest(sessionId);
            }

            await tokenService.RevokeTokenAsync(token, ct);
            return Ok();
        }

        [HttpGet("public-roles")]
        public async Task<IActionResult> GetPublicRoles(CancellationToken ct)
        {
            return Ok(await mediator.Send(new GetPublicRolesQuery(), ct));
        }

        [Authorize]
        [HttpGet("sessions")]
        public async Task<IActionResult> GetActiveSessions(CancellationToken ct)
        {
            return Ok(tokenService.GetActiveTokensByUserIdAsync(User.Id(), ct));
        }

        [HttpPost("send-confirm-code")]
        public async Task<IActionResult> SendConfirmationCode([FromQuery] string email, CancellationToken ct)
        {
            return ToActionResult(await mediator.Send(new SendConfirmationCodeCommand() { Email = email }, ct));
        }
    }
}

using System.Security.Claims;
using Application.Common.Exceptions;


namespace Application.Validators;

public static class AuthValidators
{
    public static int ValidateUserIdFromClaims(ClaimsPrincipal user)
    {
        var userIdClaim = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (!int.TryParse(userIdClaim, out var userId))
        {
            throw new UnauthorizedException("Token inválido.");
        }

        return userId;
    }
}

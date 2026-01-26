using Application.Interfaces.Behavior;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Core.Services;

public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public Guid? UserId
    {
        get
        {
            var userIdClaim = _httpContextAccessor.HttpContext?.User.FindFirst("sub") 
                              ?? _httpContextAccessor.HttpContext?.User.FindFirst("userId")
                              ?? _httpContextAccessor.HttpContext?.User.FindFirst("id");
            
            return userIdClaim != null && Guid.TryParse(userIdClaim.Value, out var userId) 
                ? userId 
                : null;
        }
    }

    public string? Token
    {
        get
        {
            var authHeader = _httpContextAccessor.HttpContext?.Request.Headers["Authorization"].FirstOrDefault();
            if (!string.IsNullOrEmpty(authHeader) && authHeader.StartsWith("Bearer "))
            {
                return authHeader.Substring("Bearer ".Length).Trim();
            }
            return null;
        }
    }
}
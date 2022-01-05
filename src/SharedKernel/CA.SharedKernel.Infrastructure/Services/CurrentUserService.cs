using CA.SharedKernel.Application.Interfaces;

using Microsoft.AspNetCore.Http;

using System.Security.Claims;

namespace CA.SharedKernel.Infrastructure.Services;

public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string UserId => _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier.ToString()).ToString();
}
using Api.Core.Common.Interfaces.Services;
using Api.Infrastructure.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Api.Infrastructure.Services;

public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IConfiguration _configuration;

    public CurrentUserService(
        IHttpContextAccessor httpContextAccessor,
        IConfiguration configuration
    )
    {
        this._httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException();
        _configuration = configuration;
    }

    public bool IsAuthenticated => this._httpContextAccessor?.HttpContext?.User?.Identity?.IsAuthenticated ?? false;

    public string IpAddress => throw new NotImplementedException();

    public string UserName => this._httpContextAccessor?.HttpContext?.User?.Identity?.Name ?? "";

    public string UserId => this._httpContextAccessor.HttpContext != null ? this.GetClaimByType("UserId") : _configuration["AdministratorId"];

    public IEnumerable<string> Permissions => GetClaimsByType(CustomClaims.Permissions);

    public Guid EnterpriseId => this._httpContextAccessor.HttpContext != null ? Guid.Parse(this.GetClaimByType("EnterpriseId")) : Guid.Parse(_configuration["EnterpriseId"]);

    public string GetClaimByType(string type)
    {
        var _Claim = this._httpContextAccessor?.HttpContext?.User?.Claims?.FirstOrDefault(x => x.Type == type);
        return _Claim?.Value ?? string.Empty;
    }

    public IEnumerable<string> GetClaimsByType(string type)
    {
        var _Claims = this._httpContextAccessor?.HttpContext?.User?.Claims?.Where(x => x.Type == type).Select(x => x.Value);
        return _Claims ?? new HashSet<string>();
    }
}
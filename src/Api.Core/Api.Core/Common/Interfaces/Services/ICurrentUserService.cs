namespace Api.Core.Common.Interfaces.Services;

public interface ICurrentUserService
{
    string UserName { get; }
    bool IsAuthenticated { get; }
    string IpAddress { get; }
    string UserId { get; }
    IEnumerable<string> Permissions { get; }
    Guid EnterpriseId { get; }
}

using Api.Core.Common.Interfaces.Services;
using Api.Core.Common.ModelsDto.Permisions;
using Microsoft.AspNetCore.Authorization;

namespace Api.Infrastructure.Authentication;

public class PermissionAuthorizationHandler : AuthorizationHandler<PermissionRequirement>
{
    private readonly ICurrentUserService _currentUser;

    public PermissionAuthorizationHandler(ICurrentUserService currentUser)
    {
        _currentUser = currentUser;
    }
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
    {
        try
        {
            var permissionsString = _currentUser.Permissions;
            var permissions = permissionsString.Select(x => new PermissionAccessDto(x.Split(":")[0], x.Split(":")[1]));
            var requiredPermission = requirement.Permission.Split(":");
            if (!(permissions?.Any() ?? false))
            {
                context.Fail();
                return Task.CompletedTask;
            }
            string module = requiredPermission!.First();
            string access = requiredPermission!.Length > 1 ? requiredPermission![1] : "";
            var accessArray = access.Split(",");
            if (permissions!.Any(x => x.Module == module && x.Access.Any(y => accessArray.Contains(y))))
            {
                context.Succeed(requirement);
            }
            else
            {
                context.Fail();
            }
        }
        catch (Exception)
        {

            context.Fail();
        }
        return Task.CompletedTask;
    }
}

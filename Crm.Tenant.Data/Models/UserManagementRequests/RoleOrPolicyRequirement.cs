/*using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

public class RoleOrPolicyRequirement : IAuthorizationRequirement
{
    public string Role { get; }
    public string Policy { get; }

    public RoleOrPolicyRequirement(string role, string policy)
    {
        Role = role;
        Policy = policy;
    }
}

public class RoleOrPolicyHandler : AuthorizationHandler<RoleOrPolicyRequirement>
{
    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, RoleOrPolicyRequirement requirement)
    {
        if (context.User == null)
        {
            return;
        }

        if (context.User.IsInRole(requirement.Role))
        {
            context.Succeed(requirement);
            return;
        }

        // Access HttpContext
        var httpContext = context.Resource as HttpContext;
        if (httpContext == null)
        {
            return;
        }

        var authorizationService = httpContext.RequestServices.GetRequiredService<IAuthorizationService>();
        var policyAuthorization = await authorizationService.AuthorizeAsync(context.User, null, requirement.Policy);

        if (policyAuthorization.Succeeded)
        {
            context.Succeed(requirement);
        }
    }
}*/

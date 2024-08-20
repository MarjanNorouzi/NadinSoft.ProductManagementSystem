using Microsoft.AspNetCore.Mvc.Filters;
using ProductManagementSystem.Application.Common.Interfaces;
using System.Security.Claims;

namespace ProductManagementSystem.API.Filter;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class CustomAuthorize : ActionFilterAttribute
{
    private readonly string _role;
    private readonly bool _allowAnonymous;

    public CustomAuthorize(bool allowAnonymous, string role)
    {
        _role = role;
        _allowAnonymous = allowAnonymous;
    }

    public CustomAuthorize(bool allowAnonymous)
    {
        _allowAnonymous = allowAnonymous;
        _role = "";
    }

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        bool isAccess = false;
        base.OnActionExecuting(context);

        var authorization = context.HttpContext.Request.Headers.Authorization.ToString();
        if (!string.IsNullOrWhiteSpace(authorization))
        {
            if (authorization.Contains("Bearer "))
            {
                var token = authorization.Replace("Bearer ", "");
                var jwtService = context.HttpContext.RequestServices.GetService<ITokenService>();
                var claimsPrincipal = jwtService.Validate(token);
                if (claimsPrincipal != null)
                {
                    var userId = claimsPrincipal.Claims.FirstOrDefault(c => c.Type == "UserId")!.Value;

                    var userContext = (IUserContext)context.HttpContext.RequestServices.GetService(typeof(IUserContext))!;
                    userContext.Id = int.Parse(userId);

                    var roleClaims = claimsPrincipal.Claims.Where(x => x.Type == ClaimTypes.Role);
                    foreach (var roleClaim in roleClaims)
                    {
                        if (_role.Contains(roleClaim.Value))
                        {
                            isAccess = true;
                            break;
                        }
                    }
                }
            }
        }

        if (_allowAnonymous)
            isAccess = true;

        if (!isAccess)
            UnAuthorize(context);
    }

    private static void UnAuthorize(ActionExecutingContext context)
    {
        context.Result = new JsonResult("Unauthorized") { StatusCode = StatusCodes.Status401Unauthorized };
    }
}

using Application.Common.Auths.Services;

namespace Api.Middlewares;

public class UserMiddleware(RequestDelegate next)
{
	public async Task InvokeAsync(HttpContext context, ICurrentUserService currentUserService)
	{
		if (context.User?.Identity?.IsAuthenticated == true)
		{
			currentUserService.SetClaimPrinciple(context.User);
		}

		await next.Invoke(context);
	}
}

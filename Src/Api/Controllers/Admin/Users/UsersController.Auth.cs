using Application.Common.ApiWrapper;
using Application.Common.Definitions.Messages;
using Application.Common.Identity.Responses;
using Application.Modules.Users.Entities;
using Application.Modules.Users.Requests.Auths;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Admin.Users;

public partial class UsersController
{
	[HttpPost("Login")]
	public async Task<ActionResult<SuccessResultResponse<AuthTokenResponse>>> LoginAsync([FromBody] LoginUserRequest request, CancellationToken cancellationToken = default)
	{
		return ResultResponse(await userService.LoginAsync(request, cancellationToken), Message<User>.Login());
	}
}

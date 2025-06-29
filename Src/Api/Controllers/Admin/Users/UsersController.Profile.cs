using Application.Common.ApiWrapper;
using Application.Common.Definitions.Messages;
using Application.Modules.Users.Entities;
using Application.Modules.Users.Responses.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Admin.Users;

public partial class UsersController
{
	[HttpGet("Me")]
	[Authorize]
	public async Task<ActionResult<SuccessResultResponse<UserResponse>>> ProfileAsync(CancellationToken cancellationToken = default)
	{
		return ResultResponse(await userService.GetProfileAsync(cancellationToken), Message<User>.Login());
	}
}

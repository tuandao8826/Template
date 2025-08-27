using Application.Common.ApiWrapper;
using Application.Common.Definitions.Messages;
using Application.Modules.Users.Bases.Responses.Users;
using Application.Modules.Users.Entities;
using Application.Modules.Users.Queries.Profile;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Admin.Users;

public partial class UsersController
{
	[HttpGet("Me")]
	[Authorize]
	public async Task<ActionResult<SuccessResultResponse<UserDefaultResponse>>> ProfileAsync(CancellationToken cancellationToken = default)
	{
		return ResultResponse(await mediator.Send(new GetUserProfileQuery(), cancellationToken), Message<User>.Login());
	}
}

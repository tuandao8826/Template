using Application.Common.ApiWrapper;
using Application.Common.Definitions.Messages;
using Application.Modules.Users.Commands.Login;
using Application.Modules.Users.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Admin.Users;

public partial class UsersController
{
	[HttpPost("Login")]
	public async Task<ActionResult<SuccessResultResponse<LoginUserResponse>>> LoginAsync([FromBody] LoginUserCommand request, CancellationToken cancellationToken = default)
	{
		return ResultResponse(await mediator.Send(request, cancellationToken), Message<User>.Login());
	}
}

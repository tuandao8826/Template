using Api.Common.ControllerWrappers;
using Application.Common.ApiWrapper;
using Application.Common.Auths.ApiKeys;
using Application.Common.Auths.Jwt;
using Application.Common.Definitions.Messages;
using Application.Common.Responses;
using Application.Modules.Users.Bases.Requests.Users;
using Application.Modules.Users.Bases.Responses.Users;
using Application.Modules.Users.Commands.Create;
using Application.Modules.Users.Entities;
using Application.Modules.Users.Queries.Detail;
using Application.Modules.Users.Services;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Admin.Users;

public partial class UsersController(IUserService userService, IMediator mediator) : AdminBaseController
{
    [HttpPost()]
    [Authorize]
    public async Task<ActionResult<SuccessResultResponse<UserDefaultResponse>>> CreateAsync([FromForm] CreateUserCommand request, CancellationToken cancellationToken = default)
    {
        return ResultResponse(await mediator.Send(request, cancellationToken), Message<User>.Create());
    }

    [HttpPut("{id:guid}")]
	[Authorize]
	public async Task<ActionResult<SuccessResultResponse<UserDefaultResponse>>> UpdateAsync([FromForm] Guid id, [FromBody] UpdateUserRequest request, CancellationToken cancellationToken = default)
    {
        return ResultResponse(await userService.UpdateAsync(id, request, cancellationToken), Message<User>.Update());
    }

    [HttpDelete]
	[Authorize]
	public async Task<ActionResult<SuccessResultResponse<MultipleIdentiferResponse>>> DeleteRangeAsync([FromBody] DeleteRangeUserRequest request, CancellationToken cancellationToken = default)
    {
        return ResultResponse(await userService.DeleteRangeAsync(request, cancellationToken), Message<User>.Delete());
    }

    [HttpGet("{id:guid}")]
    [Authorize]
    public async Task<ActionResult<SuccessResultResponse<UserDefaultResponse>>> GetDetailAsync([FromRoute] Guid id, CancellationToken cancellationToken = default)
    {
        return ResultResponse(await mediator.Send(new GetUserDetailQuery(id), cancellationToken), Message<User>.Detail());
    }
}

using Api.Common.ControllerWrappers;
using Application.Common.ApiWrapper;
using Application.Common.Auths.ApiKeys;
using Application.Common.Definitions.Messages;
using Application.Common.Responses;
using Application.Modules.Users.Entities;
using Application.Modules.Users.Requests.Users;
using Application.Modules.Users.Responses.Users;
using Application.Modules.Users.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Admin.Users;

public class UsersController(IUserService userService) : AdminBaseController
{
    [HttpPost]
    [ApiKey]
    public async Task<ActionResult<SuccessResultResponse<UserResponse>>> CreateAsync([FromForm] CreateUserRequest request, CancellationToken cancellationToken = default)
    {
        return ResultResponse(await userService.CreateAsync(request, cancellationToken), Message<User>.Create());
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<SuccessResultResponse<UserResponse>>> UpdateAsync([FromForm] Guid id, [FromBody] UpdateUserRequest request, CancellationToken cancellationToken = default)
    {
        return ResultResponse(await userService.UpdateAsync(id, request, cancellationToken), Message<User>.Update());
    }

    [HttpDelete]
    public async Task<ActionResult<SuccessResultResponse<MultipleIdentiferResponse>>> DeleteRangeAsync([FromBody] DeleteRangeUserRequest request, CancellationToken cancellationToken = default)
    {
        return ResultResponse(await userService.DeleteRangeAsync(request, cancellationToken), Message<User>.Delete());
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<SuccessResultResponse<UserResponse>>> GetDetailAsync([FromRoute] Guid id, CancellationToken cancellationToken = default)
    {
        return ResultResponse(await userService.GetDetailAsync(id, cancellationToken), Message<User>.Detail());
    }
}

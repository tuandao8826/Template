using Core.Commons.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BaseController : ControllerBase
{
	protected ActionResult<SuccessResultResponse<TData>> ResultResponse<TData>(TData? data, string? message)
	{
		return Ok(new SuccessResultResponse<TData>(data, message));
	}

	protected ActionResult<SuccessResultResponse<object>> ResultResponse(string? message)
	{
		return Ok(new SuccessResultResponse<object>(null, message));
	}
}
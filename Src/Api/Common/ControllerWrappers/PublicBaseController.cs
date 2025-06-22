using Application.Common.ApiWrapper;
using Microsoft.AspNetCore.Mvc;

namespace Api.Common.ControllerWrappers;

[Route("api/[area]/[controller]")]
[ApiController]
[Area("Public")]
[ApiExplorerSettings(GroupName = "Public")]
public class PublicBaseController : ControllerBase
{
	protected ActionResult<SuccessResultResponse<TData>> ResultResponse<TData>(TData? data, string message)
	{
		return Ok(new SuccessResultResponse<TData>(data, message));
	}

	protected ActionResult<SuccessResultResponse<object>> ResultResponse(string message)
	{
		return Ok(new SuccessResultResponse<object>(null, message));
	}
}
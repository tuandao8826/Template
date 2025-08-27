using Api.Common.ApiVersioning;
using Application.Common.ApiWrapper;
using Microsoft.AspNetCore.Mvc;

namespace Api.Common.ControllerWrappers;

[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
[Area("Public")]
[ApiExplorerSettings(GroupName = "Public")]
[ApiVersion(EndpointVersion.One)]
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
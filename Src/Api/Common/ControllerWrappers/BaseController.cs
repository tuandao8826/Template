using Application.Common.ApiWrappers;
using Microsoft.AspNetCore.Mvc;

namespace Api.Common.ControllerWrappers;

[Route("api/[controller]")]
[ApiController]
public class BaseController : ControllerBase
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
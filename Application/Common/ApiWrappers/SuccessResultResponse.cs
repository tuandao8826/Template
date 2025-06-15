using Application.Common.ApiWrappers;
using System.Net;

namespace Application.Common.ApiWrappers;

public class SuccessResultResponse<TData>(TData? data, string message) : ApiBaseResponse<TData>((int)HttpStatusCode.OK, data, message)
{
}

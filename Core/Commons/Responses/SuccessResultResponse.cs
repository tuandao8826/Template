using System.Net;

namespace Core.Commons.Responses;

public class SuccessResultResponse<TData>(TData? data, string? message) : BaseResponse<TData>((int)HttpStatusCode.OK, data, message)
{
}

using Core.Bases;

namespace Core.Commons.Responses;

public class ErrorResultResponse<TData> : BaseResponse<TData>
{
    public ErrorResultResponse(int statusCode, string? message) : base(statusCode, message)
    {
    }

	public ErrorResultResponse(int statusCode, TData? data, string? message) : base(statusCode, data, message)
	{
	}

	public string? Source { get; set; }

	public string? Exception { get; set; }
}

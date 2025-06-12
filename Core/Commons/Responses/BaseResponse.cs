namespace Core.Commons.Responses;

public abstract class BaseResponse<TData>
{
    protected BaseResponse(int statusCode, string? message)
    {
        StatusCode = statusCode;
		Message = message;
    }

	protected BaseResponse(int statusCode, TData? data, string? message)
	{
		StatusCode = statusCode;
		Data = data;
		Message = message;
	}

	public int StatusCode { get; set; }

	public string? Message { get; set; }

	public TData? Data { get; set; }
}

namespace Application.Common.ApiWrapper;

public abstract class ApiBaseResponse<TData>
{
	protected ApiBaseResponse(int statusCode, string message)
	{
		StatusCode = statusCode;
		Message = message;
	}

	protected ApiBaseResponse(int statusCode, TData? data, string message)
	{
		StatusCode = statusCode;
		Data = data;
		Message = message;
	}

	public int StatusCode { get; set; }

	public string Message { get; set; }

	public TData? Data { get; set; }
}

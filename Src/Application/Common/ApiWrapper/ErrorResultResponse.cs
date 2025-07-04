﻿using Application.Common.ApiWrapper;
using Core.Bases;

namespace Application.Common.ApiWrapper;

public class ErrorResultResponse<TData> : ApiBaseResponse<TData>
{
    public ErrorResultResponse(int statusCode, string message) : base(statusCode, message)
    {
    }

	public ErrorResultResponse(int statusCode, TData? data, string message) : base(statusCode, data, message)
	{
	}

	public string? Source { get; set; }

	public string? Exception { get; set; }
}

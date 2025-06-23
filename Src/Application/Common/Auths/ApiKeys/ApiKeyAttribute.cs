using Application.Common.Auths.Configurations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Application.Common.Auths.ApiKeys;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class ApiKeyAttribute(string keyName = nameof(ApiKeySettings.Default)) : Attribute, IAuthorizationFilter
{
	private readonly string ApiKeyHeader = "X-Api-Key";

    public void OnAuthorization(AuthorizationFilterContext context)
	{
		var request = context.HttpContext.Request;

		if (!request.Headers.TryGetValue(ApiKeyHeader, out var providedApiKey) || string.IsNullOrEmpty(providedApiKey))
		{
			context.Result = new UnauthorizedObjectResult("API Key was not provided.");
			return;
		}

		ApiKeySettings apiKeySettings = context.HttpContext.RequestServices.GetRequiredService<IOptions<SecuritySettings>>().Value.ApiKeySettings;

		string? expectedApiKey = apiKeySettings.GetType().GetProperty(keyName)?.GetValue(apiKeySettings, null)?.ToString();

		if (string.IsNullOrEmpty(expectedApiKey))
		{
			throw new ArgumentException($"API key setting '{keyName}' does not exist.");
		}

		if (!string.Equals(providedApiKey, expectedApiKey, StringComparison.Ordinal))
		{
			context.Result = new UnauthorizedObjectResult("Invalid API key.");
			return;
		}
	}
}

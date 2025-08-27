namespace Application.Common.Identity.Responses;

public class AuthTokenResponse
{
	public string AccessToken { get; set; } = default!;

	public string? RefreshToken { get; set; }
}

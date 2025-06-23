namespace Application.Common.Auths.Jwt;

internal class JwtTokenProfiles
{
	public JwtSettings Admin { get; set; } = new();

	public JwtSettings Public { get; set; } = new();
}

internal class JwtSettings
{
	public string? ValidAudience { get; set; }

	public string? ValidIssuer { get; set; }

	public string SecretKey { get; set; } = default!;

	public int TokenValidityInMinutes { get; set; }

	public int RefreshTokenValidityInDays { get; set; }
}
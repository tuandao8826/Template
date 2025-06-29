namespace Application.Common.Auths.Jwt;

public class JwtTokenProfiles
{
	public JwtSettings Admin { get; set; } = new();

	public JwtSettings Public { get; set; } = new();
}

public class JwtSettings
{
	public string? ValidAudience { get; set; }

	public string? ValidIssuer { get; set; }

	public string SecretKey { get; set; } = default!;

	public double TokenValidityInMinutes { get; set; } = 60;

	public double RefreshTokenValidityInDays { get; set; } = 1;
}
using Application.Common.Auths.ApiKeys;
using Application.Common.Auths.Jwt;

namespace Application.Common.Auths.Configurations;

public class SecuritySettings
{
	public JwtTokenProfiles JwtTokenProfiles { get; set; } = new();

	public ApiKeySettings ApiKeySettings { get; set; } = new();
}

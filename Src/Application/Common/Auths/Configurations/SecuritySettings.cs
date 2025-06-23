using Application.Common.Auths.ApiKeys;
using Application.Common.Auths.Jwt;

namespace Application.Common.Auths.Configurations;

internal class SecuritySettings
{
	public JwtTokenProfiles JwtSettings { get; set; } = new();

	public ApiKeySettings ApiKeySettings { get; set; } = new();
}

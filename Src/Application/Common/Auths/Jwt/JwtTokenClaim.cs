using Application.Common.Extensions;

namespace Application.Common.Auths.Jwt;

internal static class JwtTokenClaim
{
	public static readonly string Identification = nameof(Identification).ToLowerFirst();
	public static readonly string Role = nameof(Role).ToLowerFirst();
	public static readonly string Session = nameof(Session).ToLowerFirst();
	public static readonly string FullName = nameof(FullName).ToLowerFirst();
	public static readonly string Gender = nameof(Gender).ToLowerFirst();
	public static readonly string Email = nameof(Email).ToLowerFirst();
	public static readonly string Phone = nameof(Phone).ToLowerFirst();
	public static readonly string AvatarUrl = nameof(AvatarUrl).ToLowerFirst();
}

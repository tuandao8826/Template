using Application.Common.Auths.Jwt;
using Core.Bases;
using System.Security.Claims;

namespace Application.Common.Identity.Bases;

public interface IJwtUser : IGuidIdentify
{
	public IEnumerable<Claim> GetClaims() =>
	[
		new(JwtTokenClaim.Identification, this.Id.ToString()),
	];
}

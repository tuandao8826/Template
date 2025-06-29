using Application.Common.Auths.Jwt;
using System.Security.Claims;

namespace Application.Common.Auths.Services;

public interface ICurrentUserService
{
	public Guid Id { get; }
	
	void SetClaimPrinciple(ClaimsPrincipal user);
}

public class CurrentUserService : ICurrentUserService
{
	public Guid Id { get; private set; }

	private ClaimsPrincipal User = null!;

	public void SetClaimPrinciple(ClaimsPrincipal user)
	{
		User ??= user;

		string? id = User.FindFirst(JwtTokenClaim.Identification)?.Value;

		if (!string.IsNullOrEmpty(id))
		{
			Id = Guid.Parse(id);
		}
	}
}

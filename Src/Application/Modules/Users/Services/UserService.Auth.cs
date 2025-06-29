using Application.Common.Definitions.Messages;
using Application.Common.Extensions;
using Application.Common.Identity.Responses;
using Application.Modules.Users.Entities;
using Application.Modules.Users.Requests.Auths;
using Core.Common.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Application.Modules.Users.Services;

public partial interface IUserService
{
	Task<AuthTokenResponse> LoginAsync(LoginUserRequest request, CancellationToken cancellationToken = default);
}

public partial class UserService : IUserService
{
	public async Task<AuthTokenResponse> LoginAsync(LoginUserRequest request, CancellationToken cancellationToken = default)
	{
		User user = await unitOfWork.Repository<User>()
			.Find(x => x.Username == request.Username)
			.AsNoTracking()
			.FirstOrDefaultAsync(cancellationToken) ?? throw new BadHttpRequestException(Message<User>.Invalid());

		if (!PasswordExtension.Verify(request.Password!, user.Password))
		{
			throw new BadHttpRequestException(Message<User>.Invalid());
		}

		if (user.Status == OperationStatus.Locked)
		{
			throw new BadHttpRequestException(Message<User>.Blocked());
		}

		AuthTokenResponse authToken = new()
		{
			AccessToken = jwtTokenService.GenerateAccessToken(jwtTokenProfiles.Admin, user),
			RefreshToken = jwtTokenService.GenerateRefreshToken(),
		};

		return authToken;
	}
}

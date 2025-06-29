using Application.Common.Auths.Configurations;
using Application.Common.Auths.Jwt;
using Application.Common.Auths.Services;
using Application.Common.Definitions.Messages;
using Application.Common.Extensions;
using Application.Common.Interfaces.DependencyInjection;
using Application.Common.Interfaces.Persistence;
using Application.Common.Responses;
using Application.Modules.Users.Entities;
using Application.Modules.Users.Requests.Users;
using Application.Modules.Users.Responses.Users;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Application.Modules.Users.Services;

public partial interface IUserService : IScopedService
{
	Task<UserResponse> CreateAsync(CreateUserRequest request, CancellationToken cancellationToken = default);

	Task<UserResponse> UpdateAsync(Guid userId, UpdateUserRequest request, CancellationToken cancellationToken = default);

	Task<MultipleIdentiferResponse> DeleteRangeAsync(DeleteRangeUserRequest request, CancellationToken cancellationToken = default);

	Task<UserResponse> GetDetailAsync(Guid userId, CancellationToken cancellationToken = default);
}

public partial class UserService(
	IUnitOfWork unitOfWork,
	IMapper mapper,
	IJwtTokenService
	jwtTokenService,
	IOptions<SecuritySettings> securityOptions,
	ICurrentUserService currentUserService) : IUserService
{
	private readonly JwtTokenProfiles jwtTokenProfiles = securityOptions.Value.JwtTokenProfiles;

	public async Task<UserResponse> CreateAsync(CreateUserRequest request, CancellationToken cancellationToken = default)
	{

		User user = mapper.Map<User>(request);
		user.Password = PasswordExtension.Hash(request.Password!);

		await unitOfWork.Repository<User>().AddAsync(user, cancellationToken);
		return await GetDetailAsync(user.Id, cancellationToken);
	}

	public async Task<UserResponse> UpdateAsync(Guid userId, UpdateUserRequest request, CancellationToken cancellationToken = default)
	{
		User user = await unitOfWork.Repository<User>()
			.Find(x => x.Id == userId)
			.FirstOrDefaultAsync(cancellationToken) ?? throw new BadHttpRequestException(Message<User>.NotFound(), 400);
		mapper.Map(request, user);
		user.Password = PasswordExtension.Hash(request.Password!);

		await unitOfWork.Repository<User>().UpdateAsync(user, cancellationToken);
		return mapper.Map<UserResponse>(user);
	}

	public async Task<MultipleIdentiferResponse> DeleteRangeAsync(DeleteRangeUserRequest request, CancellationToken cancellationToken = default)
	{
		await unitOfWork.Repository<User>().Find(x => request.Ids!.Contains(x.Id)).ExecuteDeleteAsync(cancellationToken);

		return new MultipleIdentiferResponse(request.Ids!);
	}

	public async Task<UserResponse> GetDetailAsync(Guid userId, CancellationToken cancellationToken = default)
	{
		return await unitOfWork.Repository<User>()
			.Find(x => x.Id == userId)
			.AsNoTracking()
			.ProjectTo<UserResponse>(mapper.ConfigurationProvider)
			.FirstOrDefaultAsync(cancellationToken) ?? throw new BadHttpRequestException(Message<User>.NotFound(), 400);
	}
}

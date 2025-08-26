using Application.Common.Definitions.Messages;
using Application.Modules.Users.Bases.Responses.Users;
using Application.Modules.Users.Entities;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Application.Modules.Users.Services;

public partial interface IUserService
{
	Task<UserDefaultResponse> GetProfileAsync(CancellationToken cancellationToken = default);
}


public partial class UserService : IUserService
{
	public async Task<UserDefaultResponse> GetProfileAsync(CancellationToken cancellationToken = default)
	{
		return await unitOfWork.Repository<User>()
			.Find(x => x.Id == currentUserService.Id)
			.AsNoTracking()
			.ProjectTo<UserDefaultResponse>(mapper.ConfigurationProvider)
			.FirstOrDefaultAsync(cancellationToken) ?? throw new BadHttpRequestException(Message<User>.NotFound(), 400);
	}
}
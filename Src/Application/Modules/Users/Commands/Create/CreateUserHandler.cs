using Application.Common.Extensions;
using Application.Common.Interfaces.Persistence;
using Application.Modules.Users.Bases.Responses.Users;
using Application.Modules.Users.Entities;
using Application.Modules.Users.Queries.Detail;
using AutoMapper;
using MediatR;

namespace Application.Modules.Users.Commands.Create;

public class CreateUserHandler(IUnitOfWork unitOfWork, IMapper mapper, IMediator mediator) : IRequestHandler<CreateUserCommand, UserDefaultResponse>
{
    public async Task<UserDefaultResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        User user = mapper.Map<User>(request);
        user.Password = PasswordExtension.Hash(request.Password!);

        await unitOfWork.Repository<User>().AddAsync(user, cancellationToken);

        return await mediator.Send(new GetUserDetailQuery(user.Id), cancellationToken);
    }
}

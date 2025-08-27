using Application.Modules.Users.Bases.Requests.Users;
using Application.Modules.Users.Bases.Responses.Users;
using MediatR;

namespace Application.Modules.Users.Commands.Update;

public record class UpdateUserCommand(Guid UserId, UpdateUserRequest Data = null!) : IRequest<UserDefaultResponse>;

public class UpdateUserRequest : UserRequest;
using Application.Modules.Users.Bases.Requests.Users;
using Application.Modules.Users.Bases.Responses.Users;
using MediatR;

namespace Application.Modules.Users.Commands.Create;

public class CreateUserCommand : UserRequest, IRequest<UserDefaultResponse>;

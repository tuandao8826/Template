using Application.Modules.Users.Bases.Responses.Users;
using MediatR;

namespace Application.Modules.Users.Queries.Detail;

public record class GetUserDetailQuery(Guid UserId) : IRequest<UserDefaultResponse>;
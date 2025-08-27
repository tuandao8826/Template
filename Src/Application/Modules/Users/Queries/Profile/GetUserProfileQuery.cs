using Application.Modules.Users.Bases.Responses.Users;
using MediatR;

namespace Application.Modules.Users.Queries.Profile;

public class GetUserProfileQuery : IRequest<UserDefaultResponse>;
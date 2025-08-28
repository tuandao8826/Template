using Application.Modules.Roles.Bases.Responses.Roles;
using MediatR;

namespace Application.Modules.Roles.Queries.Detail;

public record class GetRoleDetailQuery(Guid RoleId) : IRequest<RoleDetailResponse>;
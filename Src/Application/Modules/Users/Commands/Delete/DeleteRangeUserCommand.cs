using Application.Common.Requests;
using Application.Common.Responses;
using MediatR;

namespace Application.Modules.Users.Commands.Delete;

public class DeleteRangeUserCommand : MultipleIdentiferRequest<Guid>, IRequest<MultipleIdentiferResponse>;
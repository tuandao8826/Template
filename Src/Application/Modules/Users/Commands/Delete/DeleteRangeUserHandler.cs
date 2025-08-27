using Application.Common.Interfaces.Persistence;
using Application.Common.Responses;
using Application.Modules.Users.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Modules.Users.Commands.Delete;

public class DeleteRangeUserHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteRangeUserCommand, MultipleIdentiferResponse>
{
    public async Task<MultipleIdentiferResponse> Handle(DeleteRangeUserCommand request, CancellationToken cancellationToken)
    {
        await unitOfWork.Repository<User>().Find(x => request.Ids!.Contains(x.Id)).ExecuteDeleteAsync(cancellationToken);

        return new MultipleIdentiferResponse(request.Ids!);
    }
}

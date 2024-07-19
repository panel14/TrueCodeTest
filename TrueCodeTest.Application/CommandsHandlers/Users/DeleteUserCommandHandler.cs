using MediatR;
using System.Net;
using TrueCodeTest.Application.Commands.Users;
using TrueCodeTest.Application.Exceptions;
using TrueCodeTest.Domain.Interfaces;

namespace TrueCodeTest.Application.CommandsHandlers.Users
{
    public class DeleteUserCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteUserCommand, Guid>
    {
        public async Task<Guid> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var deleted = await unitOfWork.Users.GetAsync(u => u.Id == request.Id) 
                ?? throw new EntityNotFoundException($"Пользователь с Id {request.Id} не найден");

            var result = await unitOfWork.Users.Delete(deleted);
            await unitOfWork.SaveChangesAsync();
            return result;
        }
    }
}

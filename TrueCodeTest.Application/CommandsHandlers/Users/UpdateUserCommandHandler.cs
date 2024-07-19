using MediatR;
using System.Net;
using TrueCodeTest.Application.Commands.Users;
using TrueCodeTest.Application.Exceptions;
using TrueCodeTest.Domain.Interfaces;

namespace TrueCodeTest.Application.CommandsHandlers.Users
{
    public class UpdateUserCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<UpdateUserCommand, Guid>
    {
        public async Task<Guid> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var oldItem = await unitOfWork.Users.GetAsync(u => u.Id == request.Id)
                ?? throw new EntityNotFoundException($"Пользователь с Id {request.Id} не найден.");

            oldItem.Name = request.Name;

            await unitOfWork.SaveChangesAsync();

            return oldItem.Id;
        }
    }
}

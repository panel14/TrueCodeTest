using MediatR;
using TrueCodeTest.Application.Commands.ToDoItems;
using TrueCodeTest.Application.Exceptions;
using TrueCodeTest.Domain.Interfaces;

namespace TrueCodeTest.Application.CommandsHandlers.ToDoItems
{
    public class AddTaskToUserCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<AddTaskToUserCommand>
    {
        public async Task Handle(AddTaskToUserCommand request, CancellationToken cancellationToken)
        {
            var task = await unitOfWork.ToDoItems.GetAsync(t => t.Id == request.TaskId) 
                ?? throw new EntityNotFoundException($"Задача с Id {request.TaskId} не найдена.");

            var user = await unitOfWork.Users.GetAsync(u => u.Id == request.UserId)
                ?? throw new EntityNotFoundException($"Пользователь с Id {request.UserId} не найден.");

            user.ToDoItems.Add(task);
            await unitOfWork.SaveChangesAsync();
        }
    }
}

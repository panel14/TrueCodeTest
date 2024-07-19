using MediatR;
using TrueCodeTest.Application.Commands.ToDoItems;
using TrueCodeTest.Application.Exceptions;
using TrueCodeTest.Domain.Interfaces;

namespace TrueCodeTest.Application.CommandsHandlers.ToDoItems
{
    public class CompliteTaskCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<CompliteTaskCommand>
    {
        public async Task Handle(CompliteTaskCommand request, CancellationToken cancellationToken)
        {
            var task = await unitOfWork.ToDoItems.GetAsync(ct => ct.Id == request.TaskId, includedProperties: ["User"])
                ?? throw new EntityNotFoundException($"Задача с Id {request.TaskId} не найдена.");

            if (task.User == null) throw new TaskNotAssignWithUserException();

            task.IsCompleted = true;
            await unitOfWork.SaveChangesAsync();
        }
    }
}

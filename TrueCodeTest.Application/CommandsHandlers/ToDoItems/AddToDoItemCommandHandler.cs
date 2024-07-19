using MediatR;
using TrueCodeTest.Application.Commands.ToDoItems;
using TrueCodeTest.Domain.Interfaces;
using TrueCodeTest.Domain.Models;

namespace TrueCodeTest.Application.CommandsHandlers.ToDoItems
{
    public class AddToDoItemCommandHandler(IUnitOfWork unitOfWork)
        : IRequestHandler<AddToDoItemCommand, Guid>
    {
        public async Task<Guid> Handle(AddToDoItemCommand request, CancellationToken cancellationToken)
        {
            var priority = await unitOfWork.Priorities.GetAsync(filter: p => p.Level == request.Priority);

            priority ??= new Priority
                {
                    Level = request.Priority
                };

            var toDoItem = new ToDoItem 
            {
                Title = request.Title,
                Description = request.Description,
                DueDate = request.DueDate,
                Priority = priority,
            };

            var result = await unitOfWork.ToDoItems.AddAsync(toDoItem);
            await unitOfWork.SaveChangesAsync();
            return result;
        }
    }
}

using MediatR;
using System.Net;
using TrueCodeTest.Application.Commands.ToDoItems;
using TrueCodeTest.Application.Exceptions;
using TrueCodeTest.Domain.Interfaces;

namespace TrueCodeTest.Application.CommandsHandlers.ToDoItems
{
    public class DeleteToDoItemCommandHandler(IUnitOfWork unitOfWork)
        : IRequestHandler<DeleteToDoItemCommand, Guid>
    {
        public async Task<Guid> Handle(DeleteToDoItemCommand request, CancellationToken cancellationToken)
        {
            var deleted = await unitOfWork.ToDoItems.GetAsync(t => t.Id == request.Id) 
                ?? throw new EntityNotFoundException($"Задача с Id {request.Id} не найдена");

            var result = await unitOfWork.ToDoItems.Delete(deleted);
            await unitOfWork.SaveChangesAsync();
            return result;
        }
    }
}

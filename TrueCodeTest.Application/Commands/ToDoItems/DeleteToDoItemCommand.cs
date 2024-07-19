using MediatR;

namespace TrueCodeTest.Application.Commands.ToDoItems
{
    public class DeleteToDoItemCommand : IRequest<Guid>
    {
        public required Guid Id { get; init; }
    }
}

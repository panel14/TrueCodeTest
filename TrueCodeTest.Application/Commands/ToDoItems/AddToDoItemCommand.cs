using MediatR;

namespace TrueCodeTest.Application.Commands.ToDoItems
{
    public class AddToDoItemCommand : IRequest<Guid>
    {
        public required string Title { get; init; }
        public required string Description { get; init; }
        public required DateTime DueDate { get; init; }
        public required int Priority { get; init; }
    }
}

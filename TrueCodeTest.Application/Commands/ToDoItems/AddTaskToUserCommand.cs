using MediatR;

namespace TrueCodeTest.Application.Commands.ToDoItems
{
    public class AddTaskToUserCommand : IRequest
    {
        public required Guid TaskId { get; init; }

        public required Guid UserId { get; init; }
    }
}

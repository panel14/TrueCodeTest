using MediatR;

namespace TrueCodeTest.Application.Commands.ToDoItems
{
    public class CompliteTaskCommand : IRequest
    {
        public required Guid TaskId { get; set; }
    }
}

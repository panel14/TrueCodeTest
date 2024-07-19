namespace TrueCodeTest.Infrastructure.Web.ToDoItems.InputModels
{
    public class AddTaskToUserInputModel
    {
        public required Guid TaskId { get; init; }

        public required Guid UserId { get; init; }
    }
}

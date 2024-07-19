namespace TrueCodeTest.Infrastructure.Web.ToDoItems.InputModels
{
    public class AddToDoItemInputModel
    {
        public required string Title { get; init; }
        public required string Description { get; init; }
        public required DateTime DueDate { get; init; }
        public required int Priority { get; init; } = 0;
    }
}

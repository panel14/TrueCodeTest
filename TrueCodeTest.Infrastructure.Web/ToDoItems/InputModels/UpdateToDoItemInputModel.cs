using TrueCodeTest.Application.Interfaces;

namespace TrueCodeTest.Infrastructure.Web.ToDoItems.InputModels
{
    public class UpdateToDoItemInputModel
    {
        public string? Title { get; init; }
        public string? Description { get; init; }
        public DateTime? DueDate { get; init; }
        public int? Priority { get; init; }
    }
}

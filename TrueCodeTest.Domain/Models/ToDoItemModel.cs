namespace TrueCodeTest.Domain.Models
{
    public class ToDoItemModel
    {
        public Guid Id { get; set; }
        public required string Title { get; init; }

        public required string Description { get; init; }

        public bool IsCompleted { get; init; }

        public DateTime DueDate { get; init; }

        public required int Priority { get; init; }

        public string? User { get; init; }
    }
}

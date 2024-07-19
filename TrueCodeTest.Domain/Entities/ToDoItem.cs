using TrueCodeTest.Domain.Entities.Abstractions;

namespace TrueCodeTest.Domain.Models
{
    public class ToDoItem : EntityBase<Guid>
    {
        public required string Title { get; set; }

        public required string Description { get; set; }

        public bool IsCompleted { get; set; }

        public DateTime DueDate { get; set; }

        public required Priority Priority { get; set; }

        public User? User { get; set; }
    }
}

using TrueCodeTest.Domain.Entities.Abstractions;

namespace TrueCodeTest.Domain.Models
{
    public class User : EntityBase<Guid>
    {
        public required string Name { get; set; }

        public IList<ToDoItem> ToDoItems { get; set; } = [];
    }
}

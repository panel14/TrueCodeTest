using TrueCodeTest.Domain.Entities.Abstractions;

namespace TrueCodeTest.Domain.Models
{
    public class Priority : EntityBase<Guid>
    {
        public int Level { get; set; }

        public IList<ToDoItem> ToDoItems { get; set; } = [];
    }
}

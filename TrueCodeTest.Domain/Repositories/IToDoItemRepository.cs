using TrueCodeTest.Domain.Interfaces;
using TrueCodeTest.Domain.Models;

namespace TrueCodeTest.Domain.Repositories
{
    public interface IToDoItemRepository : IGenericRepository<Guid, ToDoItem>;
}

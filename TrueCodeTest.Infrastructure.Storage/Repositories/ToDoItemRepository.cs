using TrueCodeTest.Domain.Models;
using TrueCodeTest.Domain.Repositories;
using TrueCodeTest.Infrastructure.Context;

namespace TrueCodeTest.Infrastructure.Repositories
{
    public class ToDoItemRepository(ApplicationDbContext context) : GenericRepository<Guid, ToDoItem>(context), IToDoItemRepository;
}

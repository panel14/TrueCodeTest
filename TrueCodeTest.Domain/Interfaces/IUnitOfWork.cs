using TrueCodeTest.Domain.Repositories;

namespace TrueCodeTest.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IToDoItemRepository ToDoItems {  get; }
        IUserRepository Users { get; }
        IPriorityRepository Priorities { get; }

        Task SaveChangesAsync();
    }
}

using TrueCodeTest.Domain.Interfaces;
using TrueCodeTest.Domain.Repositories;
using TrueCodeTest.Infrastructure.Context;

namespace TrueCodeTest.Infrastructure.Repositories
{
    public class UnitOfWork(ApplicationDbContext context) : IUnitOfWork, IDisposable
    {
        private ToDoItemRepository _toDoItemRepository = null;
        private UserRepository _userRepository = null;
        private PriorityRepository _priorityRepository = null;

        public IToDoItemRepository ToDoItems
        {
            get
            {
                _toDoItemRepository ??= new ToDoItemRepository(context);
                return _toDoItemRepository;
            }
        }

        public IUserRepository Users 
        {
            get
            {
                _userRepository ??= new UserRepository(context);
                return _userRepository;
            }
        }

        public IPriorityRepository Priorities
        {
            get 
            {
                _priorityRepository ??= new PriorityRepository(context);
                return _priorityRepository;
            }
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}

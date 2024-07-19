using TrueCodeTest.Domain.Interfaces;
using TrueCodeTest.Domain.Models;

namespace TrueCodeTest.Domain.Repositories
{
    public interface IUserRepository : IGenericRepository<Guid, User>;
}

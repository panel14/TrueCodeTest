using TrueCodeTest.Domain.Models;
using TrueCodeTest.Domain.Repositories;
using TrueCodeTest.Infrastructure.Context;

namespace TrueCodeTest.Infrastructure.Repositories
{
    public class UserRepository(ApplicationDbContext context) : GenericRepository<Guid, User>(context), IUserRepository;
}

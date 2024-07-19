using TrueCodeTest.Domain.Models;
using TrueCodeTest.Domain.Repositories;
using TrueCodeTest.Infrastructure.Context;

namespace TrueCodeTest.Infrastructure.Repositories
{
    public class PriorityRepository(ApplicationDbContext context) : GenericRepository<Guid, Priority>(context), IPriorityRepository;
}

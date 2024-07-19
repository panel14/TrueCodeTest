using MediatR;
using TrueCodeTest.Domain.Models;

namespace TrueCodeTest.Application.Queries.Users
{
    public class GetAllUsersQuery : IRequest<IEnumerable<UserModel>>;
}

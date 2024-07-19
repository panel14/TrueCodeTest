using MediatR;
using TrueCodeTest.Application.Queries.Users;
using TrueCodeTest.Domain.Interfaces;
using TrueCodeTest.Domain.Models;

namespace TrueCodeTest.Application.QueriesHandlers.Users
{
    public class GetAllUsersQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetAllUsersQuery, IEnumerable<UserModel>>
    {
        public async Task<IEnumerable<UserModel>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var result = await unitOfWork.Users.GetAllAsync();
            return result.Select(u => new UserModel { Id = u.Id, Name = u.Name });
        }
    }
}

using MediatR;
using TrueCodeTest.Application.Commands.Users;
using TrueCodeTest.Domain.Interfaces;

namespace TrueCodeTest.Application.CommandsHandlers.Users
{
    public class AddUserCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<AddUserCommand, Guid>
    {
        public async Task<Guid> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var result = await unitOfWork.Users.AddAsync(new Domain.Models.User 
            { 
                Name = request.Name 
            });
            await unitOfWork.SaveChangesAsync();
            return result;
        }
    }
}

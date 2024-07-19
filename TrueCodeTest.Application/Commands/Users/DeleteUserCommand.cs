using MediatR;

namespace TrueCodeTest.Application.Commands.Users
{
    public class DeleteUserCommand : IRequest<Guid>
    {
        public required Guid Id { get; set; }
    }
}

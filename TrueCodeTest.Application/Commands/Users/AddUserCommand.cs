using MediatR;

namespace TrueCodeTest.Application.Commands.Users
{
    public class AddUserCommand : IRequest<Guid>
    {
        public required string Name { get; init; }
    }
}

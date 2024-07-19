using MediatR;
using TrueCodeTest.Application.Interfaces;

namespace TrueCodeTest.Application.Commands.Users
{
    public class UpdateUserCommand : IRequest<Guid>, IWithId
    {
        public Guid Id { get; init; }
        public required string Name { get; set; }
    }
}

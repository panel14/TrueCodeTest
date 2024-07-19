namespace TrueCodeTest.Domain.Models
{
    public class UserModel
    {
        public Guid Id { get; set; }
        public required string Name { get; init; }
    }
}

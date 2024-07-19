using FluentValidation;
using TrueCodeTest.Infrastructure.Web.Users.InputModels;

namespace TrueCodeTest.Infrastructure.Web.Users.Validatiors
{
    public class AddUserInputModelValidator : AbstractValidator<AddUserInputModel>
    {
        public AddUserInputModelValidator() 
        {
            RuleFor(u => u.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage("Имя не может быть пустым");
        }
    }
}

using FluentValidation;
using TrueCodeTest.Infrastructure.Web.Users.InputModels;

namespace TrueCodeTest.Infrastructure.Web.Users.Validatiors
{
    public class UpdateUserInputModelValidator : AbstractValidator<UpdateUserInputModel>
    {
        public UpdateUserInputModelValidator() 
        {
            RuleFor(u => u.Name)
                .NotEmpty()
                .WithMessage("Поле не может быть пустым");
        }
    }
}

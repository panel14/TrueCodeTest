using FluentValidation;
using TrueCodeTest.Infrastructure.Web.ToDoItems.InputModels;

namespace TrueCodeTest.Infrastructure.Web.ToDoItems.Validators
{
    public class UpdateToDoItemInputModelValidator : AbstractValidator<UpdateToDoItemInputModel>
    {
        public UpdateToDoItemInputModelValidator() 
        {
            RuleFor(u => u.DueDate)
                .GreaterThan(DateTime.UtcNow)
                .WithMessage("Время выполнения должно быть позже текущего времени");
        }
    }
}

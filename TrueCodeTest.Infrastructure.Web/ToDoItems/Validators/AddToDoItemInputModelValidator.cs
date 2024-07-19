using FluentValidation;
using TrueCodeTest.Infrastructure.Web.ToDoItems.InputModels;

namespace TrueCodeTest.Infrastructure.Web.ToDoItems.Validators
{
    public class AddToDoItemInputModelValidator : AbstractValidator<AddToDoItemInputModel>
    {
        public AddToDoItemInputModelValidator() 
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(i => i.Title)
                .NotNull()
                .NotEmpty()
                .WithMessage("Заголовок задачи не может быть пустым");

            RuleFor(i => i.Description)
                .NotNull()
                .NotEmpty()
                .WithMessage("Описание задачи не может быть пустым");

            RuleFor(i => i.DueDate)
                .NotNull()
                .WithMessage("Время должно быть установлено")
                .GreaterThan(DateTime.UtcNow)
                .WithMessage("Время выполнения должно быть позже текущего времени");
        }
    }
}

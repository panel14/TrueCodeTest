using FluentValidation;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;
using TrueCodeTest.Infrastructure.Web.ToDoItems.Validators;

namespace TrueCodeTest.Api.Extensions
{
    public static class ValidationServices
    {
        public static void AddValidationServices(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<AddToDoItemInputModelValidator>();
            services.AddFluentValidationAutoValidation();
        }
    }
}

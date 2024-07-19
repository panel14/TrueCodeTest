using MediatR;
using System.Net;
using TrueCodeTest.Application.Commands.ToDoItems;
using TrueCodeTest.Application.Exceptions;
using TrueCodeTest.Domain.Interfaces;
using TrueCodeTest.Domain.Models;

namespace TrueCodeTest.Application.CommandsHandlers.ToDoItems
{
    public class UpdateToDoItemCommandHandler(IUnitOfWork unitOfWork)
        : IRequestHandler<UpdateToDoItemCommand, Guid>
    {
        private static void UpdateEntity<TFrom, TTo>(
            TFrom src, TTo dest, IEnumerable<string> excludedProperties = null)
        {
            var newProps = typeof(TFrom).GetProperties();
            var oldProps = typeof(TTo).GetProperties();

            foreach(var prop in newProps)
            {
                var value = prop.GetValue(src);
                if (value == null) continue;

                if (excludedProperties.Contains(prop.Name)) continue;

                var changedProp = Array.Find(oldProps, p => p.Name == prop.Name);
                changedProp!.SetValue(dest, value);
            }
        }

        public async Task<Guid> Handle(UpdateToDoItemCommand request, CancellationToken cancellationToken)
        {
            var oldItem = await unitOfWork.ToDoItems.GetAsync(t => t.Id == request.Id, includedProperties: ["Priority"])
                ?? throw new EntityNotFoundException($"Задача с Id {request.Id} не найдена.");

            UpdateEntity(request, oldItem, ["Id", "Priority"]);

            if (request.Priority != null && oldItem.Priority.Level != request.Priority)
            {
                var priority = await unitOfWork.Priorities.GetAsync(p => p.Level == request.Priority);

                priority ??= new Priority
                {
                    Level = request.Priority.Value,
                };

                oldItem.Priority = priority;
            }
            await unitOfWork.SaveChangesAsync();

            return oldItem.Id;
        }
    }
}

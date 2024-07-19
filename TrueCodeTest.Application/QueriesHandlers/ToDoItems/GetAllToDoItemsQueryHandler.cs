using MediatR;
using TrueCodeTest.Application.Queries.ToDoItems;
using TrueCodeTest.Domain.Interfaces;
using TrueCodeTest.Domain.Models;

namespace TrueCodeTest.Application.QueriesHandlers.ToDoItems
{
    public class GetAllToDoItemsQueryHandler(IUnitOfWork unitOfWork)
        : IRequestHandler<GetAllToDoItemsQuery, IEnumerable<ToDoItemModel>>
    {
        public async Task<IEnumerable<ToDoItemModel>> Handle(GetAllToDoItemsQuery request, CancellationToken cancellationToken)
        {
            var result = await unitOfWork.ToDoItems.GetAllAsync(filter: t => (!request.FilterByComplition || t.IsCompleted) 
            && (!request.FilterByPriority.HasValue || t.Priority.Level == request.FilterByPriority.Value),
                includeProperties: ["Priority", "User"]);

            return result.Select(t => new ToDoItemModel 
            { 
                Id = t.Id,
                Title = t.Title,
                Description = t.Description,
                IsCompleted = t.IsCompleted,
                DueDate = t.DueDate,
                Priority = t.Priority.Level,
                User = (t.User == null) ? "Не назначен" : t.User.Name,
            });
        }
    }
}

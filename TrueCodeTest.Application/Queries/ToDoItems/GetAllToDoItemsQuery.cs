using MediatR;
using TrueCodeTest.Domain.Models;

namespace TrueCodeTest.Application.Queries.ToDoItems
{
    public class GetAllToDoItemsQuery : IRequest<IEnumerable<ToDoItemModel>>
    {
        public bool FilterByComplition { get; set; }

        public int? FilterByPriority { get; set; }
    }
}

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TrueCodeTest.Application.Commands.ToDoItems;
using TrueCodeTest.Application.Queries.ToDoItems;
using TrueCodeTest.Domain.Models;
using TrueCodeTest.Infrastructure.Web.ToDoItems.InputModels;

namespace TrueCodeTest.Infrastructure.Web.ToDoItems.Controllers
{
    /// <summary>
    /// Контроллер для работы с задачами
    /// </summary>
    /// <param name="mediator">Медиатор для отправки команд и запросов</param>
    /// <param name="mapper">Маппер запросов в команды</param>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ToDoItemsController(ISender mediator, IMapper mapper) : ControllerBase
    {
        /// <summary>
        /// Получить список всех задач
        /// </summary>
        /// <param name="filterByComplition">Флаг фильтрации задач по статусу (выполненные / невыполненные)</param>
        /// <param name="filterByPriority">Фильтрация по приоритету (если значение null - фильтрации не происходит)</param>
        /// <returns>Список всех задач</returns>
        [HttpGet]
        public async Task<IEnumerable<ToDoItemModel>> GetAllItems(bool filterByComplition = false, int? filterByPriority = null)
        {
            return await mediator.Send(new GetAllToDoItemsQuery { FilterByPriority = filterByPriority, FilterByComplition = filterByComplition});
        }

        /// <summary>
        /// Добавить задачу
        /// </summary>
        /// <param name="model">Модель добавления задачи</param>
        /// <returns>Идентификатор добавленной задачи</returns>
        [HttpPost]
        public async Task<Guid> AddToDoItem(AddToDoItemInputModel model)
        {
            var dto = mapper.Map<AddToDoItemCommand>(model);
            return await mediator.Send(dto);
        }

        /// <summary>
        /// Обновить задачу
        /// </summary>
        /// <param name="id">Идентификатор задачи</param>
        /// <param name="model">Модель обновления задачи</param>
        /// <returns>Идентификатор обновленной задачи</returns>
        [HttpPut]
        [Route("{id:guid:required}")]
        public async Task<Guid> UpdateToDoItem(Guid id, UpdateToDoItemInputModel model)
        {
            var dto = mapper.Map<UpdateToDoItemCommand>(model, opt => opt.Items.Add("Id", id));
            return await mediator.Send(dto);
        }

        /// <summary>
        /// Удаление задачи
        /// </summary>
        /// <param name="id">Идентификатор задачи</param>
        /// <returns>Идентификатор удаленной задачи</returns>
        [HttpDelete]
        [Route("{id:Guid:required}")]
        public async Task<Guid> DeleteToDoItem(Guid id)
        {
            return await mediator.Send(new DeleteToDoItemCommand { Id = id });
        }

        /// <summary>
        /// Добавить задачу пользователю
        /// </summary>
        /// <param name="taskId">Идентификатор задачи</param>
        /// <param name="userId">Идентификатор пользователя</param>
        [HttpPost]
        public async Task AddTaskToUser(Guid taskId, Guid userId)
        {
            await mediator.Send(new AddTaskToUserCommand { TaskId = taskId, UserId = userId });
        }

        /// <summary>
        /// Отметить задачу как выполоненную
        /// </summary>
        /// <param name="id">Идентификатор задачи</param>
        [HttpPost]
        [Route("{id:Guid:required}")]
        public async Task CompleteTask(Guid id)
        {
            await mediator.Send(new CompliteTaskCommand { TaskId = id });
        }
    }
}

using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TrueCodeTest.Application.Commands.Users;
using TrueCodeTest.Application.Queries.Users;
using TrueCodeTest.Domain.Models;
using TrueCodeTest.Infrastructure.Web.Users.InputModels;

namespace TrueCodeTest.Infrastructure.Web.Users.Contollers
{
    /// <summary>
    /// Контроллер для работы с пользователями
    /// </summary>
    /// <param name="mediator">Медиатор для отправки команд и запросов</param>
    /// <param name="mapper">Маппер запросов в команды</param>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController(ISender mediator, IMapper mapper) : ControllerBase
    {
        /// <summary>
        /// Получить список всех пользователей
        /// </summary>
        /// <returns>Список пользователей</returns>
        [HttpGet]
        public async Task<IEnumerable<UserModel>> GetAllUsers()
        {
            return await mediator.Send(new GetAllUsersQuery());
        }

        /// <summary>
        /// Добавить пользователя
        /// </summary>
        /// <param name="model">Модель добавления пользователя</param>
        /// <returns>Идентификатор добавленного пользователя</returns>
        [HttpPost]
        public async Task<Guid> AddUser(AddUserInputModel model)
        {
            var dto = mapper.Map<AddUserCommand>(model);
            return await mediator.Send(dto);
        }

        /// <summary>
        /// Обновление пользователя
        /// </summary>
        /// <param name="id">Идентификатор пользователя</param>
        /// <param name="model">Модель обновления пользователя</param>
        /// <returns>Идентификатор обновленного пользователя</returns>
        [HttpPut]
        [Route("{id:guid:required}")]
        public async Task<Guid> UpdateUser(Guid id, UpdateUserInputModel model)
        {
            var dto = mapper.Map<UpdateUserCommand>(model, opt => opt.Items.Add("Id", id));
            return await mediator.Send(dto);
        }

        /// <summary>
        /// Удаление пользователя
        /// </summary>
        /// <param name="id">Идентификатор пользователя</param>
        /// <returns>Идентификатор удаленного пользователя</returns>
        [HttpDelete]
        [Route("{id:guid:required}")]
        public async Task<Guid> DeleteUser(Guid id)
        {
            return await mediator.Send(new DeleteUserCommand { Id = id });
        }
    }
}

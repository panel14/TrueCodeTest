

using System.Net;

namespace TrueCodeTest.Application.Exceptions
{
    public class TaskNotAssignWithUserException(string message = "Задача не назначена пользователю") : BaseException(message, (int)HttpStatusCode.Conflict);
}

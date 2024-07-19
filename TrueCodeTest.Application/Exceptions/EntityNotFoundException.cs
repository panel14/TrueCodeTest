using System.Net;

namespace TrueCodeTest.Application.Exceptions
{
    public class EntityNotFoundException(string message = "") : BaseException(message, (int)HttpStatusCode.NotFound);
}

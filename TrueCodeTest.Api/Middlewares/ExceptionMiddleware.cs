using System.Net;
using TrueCodeTest.Application.Exceptions;

namespace TrueCodeTest.Api.Middlewares
{
    public class ExceptionMiddleware(RequestDelegate next)
    {
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (Exception ex) 
            {
                await HandleExceptionMessageAsync(context, ex);
            }
        }

        private static Task HandleExceptionMessageAsync(HttpContext context, Exception exception)
        {   
            int statusCode = (int)HttpStatusCode.InternalServerError;
            string message = string.Empty;

            var result = new 
            { 
                StatusCode = statusCode,
                Message = $"Ошибка сервера. {exception.Message}",
            };

            if (exception is BaseException ex)
            {
                statusCode = ex.StatusCode;
                message = ex.Message;
            }

            context.Response.StatusCode = statusCode;
            return context.Response.WriteAsJsonAsync(result);
        }
    }
}

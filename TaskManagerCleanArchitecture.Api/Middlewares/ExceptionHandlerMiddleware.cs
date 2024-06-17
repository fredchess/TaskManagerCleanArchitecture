using System.Net;
using System.Text.Json;
using TaskManagerCleanArchitecture.Application.Exceptions;

namespace TaskManagerCleanArchitecture.Api.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;

            context.Response.ContentType = "application/json";
            var result = string.Empty;

            switch (exception)
            {
                case NotFoundException notFoundException:
                    statusCode = HttpStatusCode.NotFound;
                    break;
                case ValidationException validationException:
                    statusCode = HttpStatusCode.UnprocessableEntity;
                    result = JsonSerializer.Serialize(new {
                        errors = validationException.ValidationErrors
                    });
                    break;
                case InvalidCredentialsException invalidCredentialsException:
                    statusCode = HttpStatusCode.Unauthorized;
                    break;
                case Exception:
                    statusCode = HttpStatusCode.BadRequest;
                    break;
            }

            context.Response.StatusCode = (int) statusCode;

            if (result == string.Empty)
            {
                result = JsonSerializer.Serialize(new { error = exception.Message });
            }

            return context.Response.WriteAsync(result);
        }
    }
}
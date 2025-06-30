using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApplication.API.Common
{
    public class ExceptionFilter(ILogger<ExceptionFilter> logger) : IExceptionFilter
    {

        public async void OnException(ExceptionContext context)
        {
            var problemDetails = new ProblemDetails
            {
                Status = StatusCodes.Status500InternalServerError,
                Title = "Ошибка сервера",
                Detail = context.Exception.Message
            };

            context.Result = new ObjectResult(problemDetails)
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };

            context.ExceptionHandled = true;
        }
    }
}
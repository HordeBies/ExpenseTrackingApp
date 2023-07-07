using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ExpenseTracking.WebAPI.Filters.ExceptionFilters
{
    public class ApiExceptionFilter : IExceptionFilter
    {
        private readonly IHostEnvironment _hostEnvironment;

        public ApiExceptionFilter(IHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }

        public void OnException(ExceptionContext context)
        {
            var errors = new List<string>();
            // Don't display exception details unless running in Development.
            if (_hostEnvironment.IsDevelopment())
            {
                errors.Add(context.Exception.Message);
            }
            else
            {
                errors.Add("An Internal Error occurred");
            }

            context.Result = new ObjectResult(new
            {
                StatusCode = (int)HttpStatusCode.InternalServerError,
                Message = errors
            })
            { StatusCode = (int)HttpStatusCode.InternalServerError };
        }
    }
}


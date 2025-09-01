using Warehouse.Core.Inventory.Exceptions;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace Warehouse.API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
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
            context.Response.ContentType = "application/json";
            HttpStatusCode status = HttpStatusCode.InternalServerError;
            string message = exception.Message;

            switch (exception)
            {
                case NotFoundException:
                    status = HttpStatusCode.NotFound;
                    break;
                case ValidationException:
                    status = HttpStatusCode.BadRequest;
                    break;
                case BusinessException:
                    status = HttpStatusCode.Conflict;
                    break;
            }

            context.Response.StatusCode = (int)status;

            var result = JsonSerializer.Serialize(new
            {
                error = message,
                status = context.Response.StatusCode
            });

            return context.Response.WriteAsync(result);
        }
    }
}
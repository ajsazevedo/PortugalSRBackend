using PortugalSRBackend.Core.Common.Exceptions;
using PortugalSRBackend.Core.Objects;
using System.Net;
using System.Text.Json;

namespace PortugalSRBackend.API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static string ReturnErrorMessage(string message)
        {
            var serializeOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };

            return JsonSerializer.Serialize(Result.Failed(message), serializeOptions);
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception error)
        {
            var response = context.Response;
            response.ContentType = "application/json";

            string result;

            switch (error)
            {
                case ServiceException s:
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    result = ReturnErrorMessage(s.FriendlyMessage);
                    break;

                case GlobalException g:
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    result = ReturnErrorMessage(g.Message);
                    break;

                case ArgumentOutOfRangeException _:
                case InvalidOperationException _:
                case ArgumentException _:
                    response.StatusCode = (int)HttpStatusCode.PreconditionFailed;
                    result = ReturnErrorMessage("The request could not be proccessed.");
                    break;

                ////non handled exception
                default:
                    // unhandled error
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    result = ReturnErrorMessage("An unexpected error occurred.");
                    break;
            }

            await response.WriteAsync(result);
        }
    }
}

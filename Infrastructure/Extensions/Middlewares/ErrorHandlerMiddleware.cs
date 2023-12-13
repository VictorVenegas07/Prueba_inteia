using Application.Common.Exceptions;
using Application.Common.Wrappers;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text.Json;

namespace Infrastructure.Extensions.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {

                var response = context.Response;
                response.ContentType = "application/json";
                var responseModel = new Response<string>
                {
                    Succeeded = false,
                    Message = error.Message,
                };

                if (error is IErrorHandler errorHandler)
                {
                    await errorHandler.HandleError(context, responseModel);
                }
                else
                {
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                }

                var result = JsonSerializer.Serialize(responseModel);
                await response.WriteAsync(result);
            }
        }

    }
}

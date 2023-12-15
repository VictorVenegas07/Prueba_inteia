using Application.Common.Wrappers;
using Domain.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace Application.Exceptions
{
    public class UnauthorizedAccessException : Exception, IErrorHandler
    {
        public UnauthorizedAccessException() : base("No se pudo autenticar. Credenciales inválidas.")
        {
        }

        public UnauthorizedAccessException(string message) : base(message)
        {
        }

        public UnauthorizedAccessException(string message, Exception innerException) : base(message, innerException)
        {
        }
        public async Task HandleError(HttpContext context, Response<string> response)
        {
            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
        }
    }
}

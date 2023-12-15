using Application.Common.Exceptions;
using Application.Common.Wrappers;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace Domain.Common.Exceptions
{
    public class NoContentException : Exception, IErrorHandler
    {
        public NoContentException() : base("El recurso solicitado no contiene contenido.") { }
        public NoContentException(string message) : base(message) { }
        public async Task HandleError(HttpContext context, Response<string> response)
        {
            context.Response.StatusCode = (int)HttpStatusCode.NoContent;
        }
    }
}

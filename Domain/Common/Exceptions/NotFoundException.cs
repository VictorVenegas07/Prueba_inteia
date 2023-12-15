using Application.Common.Exceptions;
using Application.Common.Wrappers;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace Domain.Common.Exceptions
{
    public class NotFoundException : Exception, IErrorHandler
    {
        public NotFoundException() : base("Recurso no encontrado."){}
        public NotFoundException(string message) : base(message){}
        public async Task HandleError(HttpContext context, Response<string> response)
        {
           context.Response.StatusCode = (int)HttpStatusCode.NotFound;
        }
    }
}

using Application.Common.Wrappers;
using Microsoft.AspNetCore.Http;
using System.Net;
using Domain.Common.Interfaces;

namespace Application.Exceptions
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

using Application.Common.Wrappers;
using Microsoft.AspNetCore.Http;
using System.Net;
using Domain.Common.Interfaces;

namespace Application.Exceptions
{
    public class ValidationsExceptionHandler : Exception, IErrorHandler
    {
        public ValidationsExceptionHandler() : base("Han ocurrido uno o más errores de validación")
        {

            Errors = new List<string>();
        }

        public List<string> Errors { get; }

        public ValidationsExceptionHandler(IEnumerable<string> failures) : this()
        {
            Errors = failures.ToList();
        }

        public async Task HandleError(HttpContext context, Response<string> response)
        {
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            response.Errors = Errors;
        }
    }
}


using Application.Common.Wrappers;
using Domain.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Globalization;
using System.Net;

namespace Application.Exceptions
{
    public class ApiExceptionHandler : Exception, IErrorHandler
    {
        public ApiExceptionHandler() : base() { }
        public ApiExceptionHandler(string message) : base(message) { }
        public ApiExceptionHandler(string message, params object[] args) : base(string.Format(CultureInfo.CurrentCulture, message, args))
        {

        }
        public async Task HandleError(HttpContext context, Response<string> response)
        {
            context.Response.StatusCode =  (int)HttpStatusCode.BadRequest;
        }
    }
}


using System.Net;
using System.Text.Json;
using Application.Common.Wrappers;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using System.Globalization;

namespace Application.Common.Exceptions
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
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        }
    }
}

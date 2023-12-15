using Application.Common.Wrappers;
using Domain.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace Application.Exceptions
{
    public class ExistingRecordException : Exception, IErrorHandler
    {
        public ExistingRecordException(string message) : base(message) { }
        public async Task HandleError(HttpContext context, Response<string> response)
        {
            context.Response.StatusCode = (int)HttpStatusCode.Conflict;
        }
    }
}

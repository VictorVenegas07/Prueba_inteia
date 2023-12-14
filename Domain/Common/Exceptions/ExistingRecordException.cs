using Application.Common.Exceptions;
using Application.Common.Wrappers;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common.Exceptions
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

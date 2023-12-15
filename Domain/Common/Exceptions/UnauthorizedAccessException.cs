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

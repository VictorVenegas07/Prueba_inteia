using Application.Common.Wrappers;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Application.Common.Exceptions
{
    public class ValidationsExceptionHandler : Exception, IErrorHandler
    {
        public ValidationsExceptionHandler() : base("Han ocurrido uno o más errores de validación")
        {

            Errors = new List<string>();
        }

        public List<string> Errors { get; }

        public ValidationsExceptionHandler(IEnumerable<ValidationFailure> failures) : this()
        {
            Errors = failures.Select(x => x.ErrorMessage).ToList();
        }

        public async Task HandleError(HttpContext context, Response<string> response)
        {
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            response.Errors = Errors;
        }
    }
}

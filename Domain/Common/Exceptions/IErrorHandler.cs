using System.Net.Http;
using Application.Common.Wrappers;
using Microsoft.AspNetCore.Http;

namespace Application.Common.Exceptions
{
    public interface IErrorHandler
    {
        Task HandleError(HttpContext context, Response<string> response);
    }
}

using System.Net.Http;
using Application.Common.Wrappers;
using Microsoft.AspNetCore.Http;

namespace Domain.Common.Interfaces
{
    public interface IErrorHandler
    {
        Task HandleError(HttpContext context, Response<string> response);
    }
}

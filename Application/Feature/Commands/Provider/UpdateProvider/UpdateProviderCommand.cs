using Application.Common.Wrappers;
using MediatR;

namespace Application.Feature.Commands.Provider.UpdateProvider
{
    public record UpdateProviderCommand(string Id, UpdateCompanyCommand? CompanyInfo, UpdateContactCommand? ContactInfo) : IRequest<Response<string>>;
    public record UpdateCompanyCommand(string? CompanyName, string? Addressstring, string? City, string? Department, string? Email);
    public record UpdateContactCommand(string? ContactName, string? ContactEmail);
}

using Application.Common.Wrappers;
using MediatR;

namespace Application.Feature.Commands.Provider.CraeteProvider
{
    public record CraeteProviderCommand(int NIT, CreateCompanyCommand CompanyInfo, CraeteContactCommand ContactInfo ):IRequest<Response<string>>;
    public record CreateCompanyCommand(string CompanyName, string Addressstring, string City, string Department, string Email );
    public record CraeteContactCommand(string ContactName, string ContactEmail);


}

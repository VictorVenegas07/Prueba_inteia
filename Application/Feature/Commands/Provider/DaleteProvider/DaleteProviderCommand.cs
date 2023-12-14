using Application.Common.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Feature.Commands.Provider.DaleteProvider
{
    public record DaleteProviderCommand(string Id):IRequest<Response<string>>;
}

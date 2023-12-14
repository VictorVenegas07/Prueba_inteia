using Application.Common.Exceptions;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Adapters
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            this.validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if(validators.Any())
            {
                var context = new FluentValidation.ValidationContext<TRequest>(request);
                var resultValidation = await Task.WhenAll(validators.Select(x=> x.ValidateAsync(context, cancellationToken)));
                var errors = resultValidation.SelectMany(x => x.Errors).Where(x => x != null).ToList();
                if(errors.Any())
                {
                    var _errors = errors.Select(x => x.ErrorMessage).ToList();
                    throw new ValidationsExceptionHandler(_errors);
                }
            }
            return await next();
        }
    }
}

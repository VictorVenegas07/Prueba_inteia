using FluentValidation;

namespace Application.Feature.Commands.Provider.UpdateProvider
{
    public class UpdateProviderCommandValidator:AbstractValidator<UpdateProviderCommand>
    {
        public UpdateProviderCommandValidator()
        {
            RuleFor(command => command.CompanyInfo)
                .NotNull().WithMessage("La información de la compañía no puede ser nula.")
                .When(commad => commad.CompanyInfo is not null);

            RuleFor(command => command.ContactInfo)
                .NotNull().WithMessage("La información de contacto no puede ser nula.")
                .When(commad => commad.ContactInfo is not null);

            When(command => command.CompanyInfo != null, () =>
            {
                RuleFor(command => command.CompanyInfo.CompanyName)
                    .NotEmpty().WithMessage("El nombre de la compañía no puede estar vacío.")
                    .NotNull().WithMessage("El nombre de la compañía no puede ser nulo.")
                    .When(commad => commad.CompanyInfo.CompanyName is not null);

                RuleFor(command => command.CompanyInfo.Addressstring)
                    .NotEmpty().WithMessage("La dirección no puede estar vacía.")
                    .NotNull().WithMessage("La dirección no puede ser nula.")
                    .When(commad => commad.CompanyInfo.Addressstring is not null);

                RuleFor(command => command.CompanyInfo.City)
                    .NotEmpty().WithMessage("La ciudad no puede estar vacía.")
                    .NotNull().WithMessage("La ciudad no puede ser nula.")
                    .When(commad => commad.CompanyInfo.City is not null); 

                RuleFor(command => command.CompanyInfo.Department)
                    .NotEmpty().WithMessage("El departamento no puede estar vacío.")
                    .NotNull().WithMessage("El departamento no puede ser nulo.")
                    .When(commad => commad.CompanyInfo.Department is not null); ;

                RuleFor(command => command.CompanyInfo.Email)
                    .NotEmpty().WithMessage("El correo electrónico no puede estar vacío.")
                    .NotNull().WithMessage("El correo electrónico no puede ser nulo.")
                    .EmailAddress().WithMessage("El formato del correo electrónico no es válido.")
                    .When(commad => commad.CompanyInfo.Email is not null); ;
            });

            When(command => command.ContactInfo != null, () =>
            {
                RuleFor(command => command.ContactInfo.ContactName)
                    .NotEmpty().WithMessage("El nombre de contacto no puede estar vacío.")
                    .NotNull().WithMessage("El nombre de contacto no puede ser nulo.")
                    .When(commad => commad.ContactInfo.ContactName is not null); 

                RuleFor(command => command.ContactInfo.ContactEmail)
                    .NotEmpty().WithMessage("El correo electrónico de contacto no puede estar vacío.")
                    .NotNull().WithMessage("El correo electrónico de contacto no puede ser nulo.")
                    .EmailAddress().WithMessage("El formato del correo electrónico de contacto no es válido.")
                    .When(commad => commad.ContactInfo.ContactEmail is not null);

            });
        }
    }
}

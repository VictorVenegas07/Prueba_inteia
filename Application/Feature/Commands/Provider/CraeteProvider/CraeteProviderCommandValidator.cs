using FluentValidation;

namespace Application.Feature.Commands.Provider.CraeteProvider
{
    public class CraeteProviderCommandValidator: AbstractValidator<CraeteProviderCommand>
    {
            public CraeteProviderCommandValidator()
            {
                RuleFor(command => command.NIT)
                    .NotEmpty().WithMessage("El campo NIT no puede estar vacío.");

                RuleFor(command => command.CompanyInfo)
                    .SetValidator(new CreateCompanyCommandValidator());

                RuleFor(command => command.ContactInfo)
                    .SetValidator(new CraeteContactCommandValidator());
            }
    }

        public class CreateCompanyCommandValidator : AbstractValidator<CreateCompanyCommand>
        {
            public CreateCompanyCommandValidator()
            {
                RuleFor(command => command.CompanyName)
                    .NotEmpty().WithMessage("El nombre de la compañía no puede estar vacío.")
                    .MinimumLength(3).WithMessage("El nombre de la compañía debe tener al menos 3 caracteres.")
                    .MaximumLength(100).WithMessage("El nombre de la compañía no puede tener más de 100 caracteres.");

                RuleFor(command => command.Addressstring)
                     .NotEmpty().WithMessage("La dirección no puede estar vacía.")
                     .MinimumLength(5).WithMessage("La dirección debe tener al menos 5 caracteres.")
                     .MaximumLength(200).WithMessage("La dirección no puede tener más de 200 caracteres.");

                RuleFor(command => command.City)
                     .NotEmpty().WithMessage("La ciudad no puede estar vacía.")
                     .MaximumLength(50).WithMessage("La ciudad no puede tener más de 50 caracteres.");

                RuleFor(command => command.Department)
                    .NotEmpty().WithMessage("El departamento no puede estar vacío.")
                    .MaximumLength(50).WithMessage("El departamento no puede tener más de 50 caracteres.");

                RuleFor(command => command.Email)
                     .NotEmpty().WithMessage("El correo electrónico no puede estar vacío.")
                     .EmailAddress().WithMessage("El formato del correo electrónico no es válido.")
                     .MaximumLength(100).WithMessage("El correo electrónico no puede tener más de 100 caracteres.");
            }
 
        }

        public class CraeteContactCommandValidator : AbstractValidator<CraeteContactCommand>
        {
            public CraeteContactCommandValidator(){

                RuleFor(command => command.ContactName)
                       .NotEmpty().WithMessage("El nombre de contacto no puede estar vacío.")
                       .MinimumLength(3).WithMessage("El nombre de contacto debe tener al menos 3 caracteres.")
                       .MaximumLength(50).WithMessage("El nombre de contacto no puede tener más de 50 caracteres.");

                RuleFor(command => command.ContactEmail)
                        .NotEmpty().WithMessage("El correo electrónico de contacto no puede estar vacío.")
                        .EmailAddress().WithMessage("El formato del correo electrónico de contacto no es válido.")
                        .MaximumLength(100).WithMessage("El correo electrónico de contacto no puede tener más de 100 caracteres.");
            }
        }
 }


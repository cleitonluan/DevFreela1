using DevFreela.Application.Commands.CreateUser;
using FluentValidation;
using System.Text.RegularExpressions;

namespace DevFreela.Application.Validations
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(p => p.Email)
                .EmailAddress()
                .WithMessage("E-Mail não valido!");

            RuleFor(p => p.Password)
                .Must(ValidPassword)
                .WithMessage(" A senha deve conter pelo menos 8 caracteres, um numero , uma letra maiuscula, uma minuscuala e um caractere especial");

            RuleFor(p => p.FullName)
                .NotEmpty()
                .NotNull()
                .WithMessage(" O nome é obrigatorio!");
                 
        }
        public bool ValidPassword(string password)
        {
            var regex = new Regex(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$");

            return regex.IsMatch(password);
        }
    }
}

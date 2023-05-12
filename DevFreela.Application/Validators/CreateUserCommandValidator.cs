using DevFreela.Application.Commands.CommandsUser.CreateUser;
using FluentValidation;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace DevFreela.Application.Validators
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.Email)
                .EmailAddress()
                .WithMessage("E-mail não e válido! ");

            RuleFor(x => x.FullName)
                .NotNull()
                .NotEmpty()
                .WithMessage("Por favor informe um nome");

            RuleFor(x => x.BirthDate)
                .GreaterThan(DateTime.Now)
                .WithMessage("Data invalida");
            RuleFor(x =>x)
                .Must(ValidarPassword)
                .WithMessage("Senha deve conter pelo menos 8 caracteres, um número, uma letra maiúscula, uma minúscula, e um caractere especial");
        }
        private bool ValidarPassword(CreateUserCommand createUserCommand)
        {
            var regex = new Regex(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$");
            return regex.IsMatch(createUserCommand.Password);
        }
    }
}

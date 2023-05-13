using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DevFreela.Application.Commands.CreateUser;
using FluentValidation;

namespace DevFreela.Application.Validators
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.Email)
                .EmailAddress()
                .NotEmpty()
                .WithMessage("Invalid email!");
            
            RuleFor(x => x.Password)
                .Must(ValidPassword)
                .WithMessage("The password must contain at least 8 characters, a number, an uppercase letter, a lowercase letter and a special character!");

            RuleFor(x => x.FullName)
                .NotEmpty()
                .NotNull()
                .WithMessage("Name is required!");      
        }

        public bool ValidPassword(string password)
        {
            var regex = new Regex(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$");

            return regex.IsMatch(password);
        }
    }
}
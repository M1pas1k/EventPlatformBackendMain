using FluentValidation;
using WebApplication.Application.Features.Users.Commands;

namespace WebApplication.Application.Validators
{
    public class CreateUserValidation : AbstractValidator<CreateUserCommand>
    {
        public CreateUserValidation()
        {
            RuleFor(u => u.Entity.PhoneNumber)
                .NotEmpty()
                .WithMessage("Number must not be empty");

            RuleFor(u => u.Entity.Password)
                .NotEmpty()
                .MinimumLength(8)
                .WithMessage("Password must be greater then 8")
                .MaximumLength(100)
                .WithMessage("Password must be less then 100");

            RuleFor(u => u.Entity.Name)
                .NotEmpty()
                .WithMessage("Username must not be empty");

            RuleFor(u => u.Entity.Email)
                .NotEmpty()
                .EmailAddress()
                .WithMessage("Email is incorrect");

            RuleFor(u => u.Entity.ConfirmationCode)
                .NotEmpty()
                .WithMessage("Confirmation code should not be empty");
        }
    }
}

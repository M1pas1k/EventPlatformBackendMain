using FluentValidation;
using WebApplication.Application.Features.Users.Commands;

namespace WebApplication.Application.Validators
{
    public class UpdateUserValidation : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserValidation()
        {
            RuleFor(u => u.User.PhoneNumber)
                .NotEmpty()
                .WithMessage("Number must not be empty");

            RuleFor(u => u.User.Name)
                .NotEmpty()
                .WithMessage("Username must not be empty");
        }
    }
}

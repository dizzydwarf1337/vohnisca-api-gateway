using FluentValidation;

namespace Application.Commands.Public.Auth.SignUp;

public class SignUpCommandValidator : AbstractValidator<SignUpCommand>
{
    public SignUpCommandValidator()
    {
        RuleFor(x => x.Email).NotEmpty().EmailAddress().WithName("Email");
        RuleFor(x => x.Password).NotEmpty().WithName("Password");
        RuleFor(x => x.PasswordConfirmation).NotEmpty().Equal(x=>x.Password).WithName("Password confirmation");
        RuleFor(x => x.Name).NotEmpty().WithName("Nickname");
    }
}
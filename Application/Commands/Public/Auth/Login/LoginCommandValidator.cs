using FluentValidation;

namespace Application.Commands.Public.Auth.Login;

public class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(x => x.Email).NotEmpty().EmailAddress().WithName("Email");
        RuleFor(x => x.Password).NotEmpty().WithName("Password");
    }
}
using FluentValidation;

namespace Application.Commands.Admin.Mail;

public class SendMailCommandValidator : AbstractValidator<SendMailCommand>
{
    public SendMailCommandValidator()
    {
        RuleFor(x => x.Email).NotEmpty().EmailAddress().WithName("Email");
        RuleFor(x=>x.Content).NotEmpty().WithName("Content");
        RuleFor(x=>x.Subject).NotEmpty().WithName("Subject");
    }
}
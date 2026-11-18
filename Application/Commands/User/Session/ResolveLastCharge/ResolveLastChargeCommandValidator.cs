using FluentValidation;

namespace Application.Commands.User.Session.ResolveLastCharge;

public class ResolveLastChargeCommandValidator : AbstractValidator<ResolveLastChargeCommand>
{
    public ResolveLastChargeCommandValidator()
    {
        RuleFor(x => x.SessionId).NotEmpty();
        RuleFor(x => x.CharacterId).NotEmpty();
        RuleFor(x => x.InstanceId).NotEmpty();
        RuleFor(x => x.Decision).Must(d => d is "keep" or "inert" or "destroy").WithMessage("Decision: keep, inert or destroy");
    }
}

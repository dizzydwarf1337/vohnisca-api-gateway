using FluentValidation;

namespace Application.Commands.User.Character.ExpendCharges;

public class ExpendChargesCommandValidator : AbstractValidator<ExpendChargesCommand>
{
    public ExpendChargesCommandValidator()
    {
        RuleFor(x => x.CharacterId).NotEmpty();
        RuleFor(x => x.InstanceId).NotEmpty();
        RuleFor(x => x.OperationId).NotEmpty();
        RuleFor(x => x.Count).InclusiveBetween(1, 100);
    }
}

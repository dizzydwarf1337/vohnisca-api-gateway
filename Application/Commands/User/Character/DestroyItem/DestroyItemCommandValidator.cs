using FluentValidation;

namespace Application.Commands.User.Character.DestroyItem;

public class DestroyItemCommandValidator : AbstractValidator<DestroyItemCommand>
{
    public DestroyItemCommandValidator()
    {
        RuleFor(x => x.CharacterId).NotEmpty();
        RuleFor(x => x.InstanceId).NotEmpty();
        RuleFor(x => x.OperationId).NotEmpty();
    }
}

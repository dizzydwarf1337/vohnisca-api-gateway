using FluentValidation;

namespace Application.Commands.User.Character.ResolveItemStack;

public class ResolveItemStackCommandValidator : AbstractValidator<ResolveItemStackCommand>
{
    public ResolveItemStackCommandValidator()
    {
        RuleFor(x => x.CharacterId).NotEmpty();
        RuleFor(x => x.ItemId).NotEmpty();
        RuleFor(x => x.OperationId).NotEmpty();
    }
}

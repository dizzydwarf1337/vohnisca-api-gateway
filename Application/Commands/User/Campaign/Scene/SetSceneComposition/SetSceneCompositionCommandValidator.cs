using FluentValidation;

namespace Application.Commands.User.Campaign.Scene.SetSceneComposition;

public class SetSceneCompositionCommandValidator : AbstractValidator<SetSceneCompositionCommand>
{
    public SetSceneCompositionCommandValidator()
    {
        RuleFor(x => x.CardId).NotEmpty();
        RuleForEach(x => x.Npcs).ChildRules(entry =>
        {
            entry.RuleFor(e => e.NpcId).NotEmpty();
            entry.RuleFor(e => e.Count).GreaterThanOrEqualTo(1);
        });
        RuleForEach(x => x.Items).ChildRules(entry =>
        {
            entry.RuleFor(e => e.RefId).NotEmpty();
            entry.RuleFor(e => e.Quantity).GreaterThanOrEqualTo(1);
        });
    }
}
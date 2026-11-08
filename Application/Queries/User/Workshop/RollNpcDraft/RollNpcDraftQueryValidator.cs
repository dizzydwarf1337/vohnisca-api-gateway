using FluentValidation;

namespace Application.Queries.User.Workshop.RollNpcDraft;

public class RollNpcDraftQueryValidator : AbstractValidator<RollNpcDraftQuery>
{
    public RollNpcDraftQueryValidator()
    {
        RuleFor(x => x.Role)
            .Must(role => string.IsNullOrWhiteSpace(role)
                          || string.Equals(role.Trim(), "bestiary", StringComparison.OrdinalIgnoreCase)
                          || string.Equals(role.Trim(), "character", StringComparison.OrdinalIgnoreCase))
            .WithMessage("A draft is a bestiary or a character");
        RuleFor(x => x.Level).InclusiveBetween(1, 20).When(x => x.Level is not null).WithName("Level");
    }
}

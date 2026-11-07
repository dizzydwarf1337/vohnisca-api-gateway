using FluentValidation;

namespace Application.Commands.User.Workshop.SaveMapLevel;

public class SaveMapLevelCommandValidator : AbstractValidator<SaveMapLevelCommand>
{
    public SaveMapLevelCommandValidator()
    {
        RuleFor(x => x.MapId).NotEmpty();
        RuleFor(x => x.Name).NotEmpty().MaximumLength(255);
        RuleFor(x => x.Scene).NotEmpty();
        RuleFor(x => x.Cols).InclusiveBetween(1, 200);
        RuleFor(x => x.Rows).InclusiveBetween(1, 200);
    }
}
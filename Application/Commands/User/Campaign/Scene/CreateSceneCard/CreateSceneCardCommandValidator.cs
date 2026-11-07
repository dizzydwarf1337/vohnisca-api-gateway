using Application.Core.Validation;
using FluentValidation;

namespace Application.Commands.User.Campaign.Scene.CreateSceneCard;

public class CreateSceneCardCommandValidator : AbstractValidator<CreateSceneCardCommand>
{
    public CreateSceneCardCommandValidator()
    {
        RuleFor(x => x.CampaignId).NotEmpty();
        RuleFor(x => x.SceneType).Must(SceneTypes.IsKnown)
            .WithMessage("SceneType must be 'table' or 'handout'.");
        RuleFor(x => x.Title).NotEmpty().MaximumLength(255);
        RuleFor(x => x.Content).MaximumLength(100000);
        RuleFor(x => x.ContentFormat).Must(ContentFormats.IsKnown)
            .WithMessage("ContentFormat must be 'text' or 'html'.");
        // A table scene without a level has nothing for the table to load; a handout needs no map at all.
        RuleFor(x => x.LevelId).NotEmpty()
            .When(x => x.SceneType == SceneTypes.Table);
    }
}
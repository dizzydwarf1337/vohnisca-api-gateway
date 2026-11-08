using Application.Core.Validation;
using FluentValidation;

namespace Application.Commands.User.Campaign.Card.CreateItemCard;

public class CreateItemCardCommandValidator : AbstractValidator<CreateItemCardCommand>
{
    public CreateItemCardCommandValidator()
    {
        RuleFor(x => x.CampaignId).NotEmpty();
        RuleFor(x => x.RefId).NotEmpty();
        RuleFor(x => x.Quantity).GreaterThanOrEqualTo(1);
        RuleFor(x => x.Title).MaximumLength(255);
        RuleFor(x => x.Content).MaximumLength(100000);
        RuleFor(x => x.ContentFormat).Must(ContentFormats.IsKnown)
            .WithMessage("ContentFormat must be 'text' or 'html'.");
    }
}
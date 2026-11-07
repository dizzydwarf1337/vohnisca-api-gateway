using System.Text.Json;
using Application.Core.Validation;
using FluentValidation;

namespace Application.Commands.User.Campaign.Shop.UpdateShopCard;

public class UpdateShopCardCommandValidator : AbstractValidator<UpdateShopCardCommand>
{
    public UpdateShopCardCommandValidator()
    {
        RuleFor(x => x.CardId).NotEmpty();
        RuleFor(x => x.Title).MaximumLength(255);
        RuleFor(x => x.Content).MaximumLength(100000);
        RuleFor(x => x.ContentFormat).Must(ContentFormats.IsKnown)
            .WithMessage("ContentFormat must be 'text' or 'html'.");
        RuleFor(x => x.Meta).Must(meta => meta is null || meta.Value.ValueKind == JsonValueKind.Object)
            .WithMessage("Meta must be a JSON object.");
    }
}
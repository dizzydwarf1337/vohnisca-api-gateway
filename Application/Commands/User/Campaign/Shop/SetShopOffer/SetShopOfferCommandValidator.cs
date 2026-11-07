using FluentValidation;

namespace Application.Commands.User.Campaign.Shop.SetShopOffer;

public class SetShopOfferCommandValidator : AbstractValidator<SetShopOfferCommand>
{
    public SetShopOfferCommandValidator()
    {
        RuleFor(x => x.GoodId).NotEmpty();
        RuleFor(x => x.TargetUserId).NotEmpty();
        RuleFor(x => x.PriceCoins).GreaterThanOrEqualTo(0);
    }
}
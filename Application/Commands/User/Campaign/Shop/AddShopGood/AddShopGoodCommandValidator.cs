using FluentValidation;

namespace Application.Commands.User.Campaign.Shop.AddShopGood;

public class AddShopGoodCommandValidator : AbstractValidator<AddShopGoodCommand>
{
    public AddShopGoodCommandValidator()
    {
        RuleFor(x => x.CardId).NotEmpty();
        RuleFor(x => x.RefId).NotEmpty();
        RuleFor(x => x.PriceCoins).GreaterThanOrEqualTo(0);
        RuleFor(x => x.SellPriceCoins).GreaterThanOrEqualTo(0)
            .When(x => x.SellPriceCoins is not null);
        RuleFor(x => x.Stock).GreaterThanOrEqualTo(0)
            .When(x => x.Stock is not null);
    }
}
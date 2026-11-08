using FluentValidation;

namespace Application.Commands.User.Campaign.Shop.BuyFromShop;

public class BuyFromShopCommandValidator : AbstractValidator<BuyFromShopCommand>
{
    public BuyFromShopCommandValidator()
    {
        RuleFor(x => x.CardId).NotEmpty();
        RuleFor(x => x.GoodId).NotEmpty();
        RuleFor(x => x.CharacterId).NotEmpty();
        RuleFor(x => x.Quantity).GreaterThanOrEqualTo(1);
    }
}
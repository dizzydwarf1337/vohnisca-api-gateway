using FluentValidation;

namespace Application.Commands.User.Campaign.Shop.SellToShop;

public class SellToShopCommandValidator : AbstractValidator<SellToShopCommand>
{
    public SellToShopCommandValidator()
    {
        RuleFor(x => x.CardId).NotEmpty();
        RuleFor(x => x.ItemCardId).NotEmpty();
    }
}
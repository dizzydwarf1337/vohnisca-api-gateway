using FluentValidation;

namespace Application.Commands.User.Campaign.Shop.RemoveShopGood;

public class RemoveShopGoodCommandValidator : AbstractValidator<RemoveShopGoodCommand>
{
    public RemoveShopGoodCommandValidator()
    {
        RuleFor(x => x.GoodId).NotEmpty();
    }
}
using System.Text.Json;
using FluentValidation;

namespace Application.Commands.User.Campaign.Shop.UpdateShopGood;

public class UpdateShopGoodCommandValidator : AbstractValidator<UpdateShopGoodCommand>
{
    public UpdateShopGoodCommandValidator()
    {
        RuleFor(x => x.GoodId).NotEmpty();
        RuleFor(x => x.PriceCoins).GreaterThanOrEqualTo(0)
            .When(x => x.PriceCoins is not null);
        RuleFor(x => x.SellPriceCoins).GreaterThanOrEqualTo(0)
            .When(x => x.SellPriceCoins is not null);
        RuleFor(x => x.Order).GreaterThanOrEqualTo(0)
            .When(x => x.Order is not null);
        RuleFor(x => x.Stock).Must(BeAStockCount)
            .WithMessage("Stock must be a count of zero or more; null means no limit.");
    }

    private static bool BeAStockCount(JsonElement stock) => stock.ValueKind switch
    {
        JsonValueKind.Undefined or JsonValueKind.Null => true,
        JsonValueKind.Number => stock.TryGetInt32(out var count) && count >= 0,
        _ => false,
    };
}
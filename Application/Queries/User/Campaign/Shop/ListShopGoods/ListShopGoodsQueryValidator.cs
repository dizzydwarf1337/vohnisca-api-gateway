using FluentValidation;

namespace Application.Queries.User.Campaign.Shop.ListShopGoods;

public class ListShopGoodsQueryValidator : AbstractValidator<ListShopGoodsQuery>
{
    public ListShopGoodsQueryValidator()
    {
        RuleFor(x => x.CardId).NotEmpty();
    }
}
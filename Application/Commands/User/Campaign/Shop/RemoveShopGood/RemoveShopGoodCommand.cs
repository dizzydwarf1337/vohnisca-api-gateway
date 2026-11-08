using Application.Core.Mediatr.Requests.UserRequest;
using MediatR;

namespace Application.Commands.User.Campaign.Shop.RemoveShopGood;

public class RemoveShopGoodCommand : UserRequest<Unit>
{
    public Guid GoodId { get; set; }
}
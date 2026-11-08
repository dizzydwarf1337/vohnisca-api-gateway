using Application.Commands.User.Campaign.Shop.AddShopGood;
using Application.Commands.User.Campaign.Shop.ApprovePurchase;
using Application.Commands.User.Campaign.Shop.BuyFromShop;
using Application.Commands.User.Campaign.Shop.CreateShopCard;
using Application.Commands.User.Campaign.Shop.RemoveShopGood;
using Application.Commands.User.Campaign.Shop.SellToShop;
using Application.Commands.User.Campaign.Shop.SetShopOffer;
using Application.Commands.User.Campaign.Shop.UpdateShopCard;
using Application.Commands.User.Campaign.Shop.UpdateShopGood;
using Application.Core.Validation;
using Application.Queries.User.Campaign.Card.GetCampaignCard;
using Application.Queries.User.Campaign.Card.ListCampaignCards;
using Application.Queries.User.Campaign.Shop.ListShopGoods;
using Microsoft.AspNetCore.Mvc;

namespace vohnisca_api_gateway.Controllers.User.CampaignService;

// Shops are cards of kind "shop" with a shelf of workshop types (goods), prices, stock and offers, and the
// purchases that character-service settles over the bus. A shop card itself is read and listed through the
// card routes of stage 00 — the kind is the only difference — so the two list/get actions here reuse them.
[Route("campaign-shop-cards")]
public class ShopController : BaseController
{
    [HttpGet]
    [Route("/campaigns/{id:guid}/shop-cards")]
    public async Task<IActionResult> ListShopCards(Guid id, [FromQuery] Guid? chapterId,
        [FromQuery] int page = 1, [FromQuery] int pageSize = 50)
    {
        if (id == Guid.Empty)
            return BadRequest();

        return await HandleResponse(new ListCampaignCardsQuery
        {
            CampaignId = id,
            Kind = CardKinds.Shop,
            ChapterId = chapterId,
            Page = page,
            PageSize = pageSize,
        });
    }

    [HttpPost]
    [Route("/campaigns/{id:guid}/shop-cards")]
    public async Task<IActionResult> CreateShopCard(Guid id, CreateShopCardCommand command)
    {
        if (id == Guid.Empty || command is null)
            return BadRequest();

        command.CampaignId = id;

        return await HandleResponse(command);
    }

    [HttpGet]
    [Route("{id:guid}")]
    public async Task<IActionResult> GetShopCard(Guid id)
    {
        if (id == Guid.Empty)
            return BadRequest();

        return await HandleResponse(new GetCampaignCardQuery { CardId = id });
    }

    [HttpPut]
    [Route("{id:guid}")]
    public async Task<IActionResult> UpdateShopCard(Guid id, UpdateShopCardCommand command)
    {
        if (id == Guid.Empty || command is null)
            return BadRequest();

        command.CardId = id;

        return await HandleResponse(command);
    }

    [HttpGet]
    [Route("{id:guid}/goods")]
    public async Task<IActionResult> ListShopGoods(Guid id)
    {
        if (id == Guid.Empty)
            return BadRequest();

        return await HandleResponse(new ListShopGoodsQuery { CardId = id });
    }

    [HttpPost]
    [Route("{id:guid}/goods")]
    public async Task<IActionResult> AddShopGood(Guid id, AddShopGoodCommand command)
    {
        if (id == Guid.Empty || command is null)
            return BadRequest();

        command.CardId = id;

        return await HandleResponse(command);
    }

    [HttpPut]
    [Route("/shop-goods/{id:guid}")]
    public async Task<IActionResult> UpdateShopGood(Guid id, UpdateShopGoodCommand command)
    {
        if (id == Guid.Empty || command is null)
            return BadRequest();

        command.GoodId = id;

        return await HandleResponse(command);
    }

    [HttpDelete]
    [Route("/shop-goods/{id:guid}")]
    public async Task<IActionResult> RemoveShopGood(Guid id)
    {
        if (id == Guid.Empty)
            return BadRequest();

        return await HandleResponse(new RemoveShopGoodCommand { GoodId = id });
    }

    [HttpPut]
    [Route("/shop-goods/{id:guid}/offers")]
    public async Task<IActionResult> SetShopOffer(Guid id, SetShopOfferCommand command)
    {
        if (id == Guid.Empty || command is null)
            return BadRequest();

        command.GoodId = id;

        return await HandleResponse(command);
    }

    [HttpPost]
    [Route("{id:guid}/buy")]
    public async Task<IActionResult> BuyFromShop(Guid id, BuyFromShopCommand command)
    {
        if (id == Guid.Empty || command is null)
            return BadRequest();

        command.CardId = id;

        return await HandleResponse(command);
    }

    [HttpPost]
    [Route("{id:guid}/sell")]
    public async Task<IActionResult> SellToShop(Guid id, SellToShopCommand command)
    {
        if (id == Guid.Empty || command is null)
            return BadRequest();

        command.CardId = id;

        return await HandleResponse(command);
    }

    [HttpPost]
    [Route("/shop-purchases/{id:guid}/approve")]
    public async Task<IActionResult> ApprovePurchase(Guid id)
    {
        if (id == Guid.Empty)
            return BadRequest();

        return await HandleResponse(new ApprovePurchaseCommand { PurchaseId = id });
    }
}
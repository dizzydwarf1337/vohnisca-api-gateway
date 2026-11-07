using Application.Commands.User.Campaign.Card.CreateItemCard;
using Application.Commands.User.Campaign.Card.CreateNpcCard;
using Application.Commands.User.Campaign.Card.GrantCampaignCardAccess;
using Application.Commands.User.Campaign.Card.MoveItemCard;
using Application.Commands.User.Campaign.Card.ReorderCampaignCards;
using Application.Commands.User.Campaign.Card.RevokeCampaignCardAccess;
using Application.Commands.User.Campaign.Card.SetCampaignCardVisibility;
using Application.Commands.User.Campaign.Card.UpdateCampaignCard;
using Application.Queries.User.Campaign.Card.GetCampaignCard;
using Application.Queries.User.Campaign.Card.ListCampaignCards;
using Application.Queries.User.Campaign.Card.ListItemCards;
using Microsoft.AspNetCore.Mvc;

namespace vohnisca_api_gateway.Controllers.User.CampaignService;

// The cards of a campaign: notes that carry a kind (note, npc, item, shop, stash, scene), an optional
// reference to a workshop entry and kind-specific meta.
[Route("campaign-cards")]
public class CampaignCardController : BaseController
{
    [HttpGet]
    [Route("/campaigns/{id:guid}/cards")]
    public async Task<IActionResult> ListCampaignCards(Guid id, [FromQuery] string? kind, [FromQuery] Guid? chapterId,
        [FromQuery] int page = 1, [FromQuery] int pageSize = 50)
    {
        if (id == Guid.Empty)
            return BadRequest();

        return await HandleResponse(new ListCampaignCardsQuery
        { CampaignId = id, Kind = kind, ChapterId = chapterId, Page = page, PageSize = pageSize });
    }

    // A card that points at a workshop NPC (the entity is the workshop's, the card is the campaign's).
    [HttpPost]
    [Route("/campaigns/{id:guid}/npc-cards")]
    public async Task<IActionResult> CreateNpcCard(Guid id, CreateNpcCardCommand command)
    {
        if (id == Guid.Empty || command is null)
            return BadRequest();

        command.CampaignId = id;

        return await HandleResponse(command);
    }

    // The item cards as a tree: a container (bag, sack, chest, loot) carries its contents in Children.
    [HttpGet]
    [Route("/campaigns/{id:guid}/item-cards")]
    public async Task<IActionResult> ListItemCards(Guid id, [FromQuery] Guid? chapterId, [FromQuery] Guid? containerId,
        [FromQuery] int page = 1, [FromQuery] int pageSize = 50)
    {
        if (id == Guid.Empty)
            return BadRequest();

        return await HandleResponse(new ListItemCardsQuery
        { CampaignId = id, ChapterId = chapterId, ContainerId = containerId, Page = page, PageSize = pageSize });
    }

    // An instance of a workshop item type: the type is the workshop's, the instance is the campaign's.
    [HttpPost]
    [Route("/campaigns/{id:guid}/item-cards")]
    public async Task<IActionResult> CreateItemCard(Guid id, CreateItemCardCommand command)
    {
        if (id == Guid.Empty || command is null)
            return BadRequest();

        command.CampaignId = id;

        return await HandleResponse(command);
    }

    [HttpPost]
    [Route("/campaign-item-cards/{id:guid}/move")]
    public async Task<IActionResult> MoveItemCard(Guid id, MoveItemCardCommand command)
    {
        if (id == Guid.Empty || command is null)
            return BadRequest();

        command.CardId = id;

        return await HandleResponse(command);
    }

    [HttpGet]
    [Route("{id:guid}")]
    public async Task<IActionResult> GetCampaignCard(Guid id)
    {
        if (id == Guid.Empty)
            return BadRequest();

        return await HandleResponse(new GetCampaignCardQuery { CardId = id });
    }

    [HttpPut]
    [Route("{id:guid}")]
    public async Task<IActionResult> UpdateCampaignCard(Guid id, UpdateCampaignCardCommand command)
    {
        if (id == Guid.Empty || command is null)
            return BadRequest();

        command.CardId = id;

        return await HandleResponse(command);
    }

    [HttpPut]
    [Route("{id:guid}/visibility")]
    public async Task<IActionResult> SetCampaignCardVisibility(Guid id, SetCampaignCardVisibilityCommand command)
    {
        if (id == Guid.Empty || command is null)
            return BadRequest();

        command.CardId = id;

        return await HandleResponse(command);
    }

    [HttpPost]
    [Route("{id:guid}/access")]
    public async Task<IActionResult> GrantCampaignCardAccess(Guid id, GrantCampaignCardAccessCommand command)
    {
        if (id == Guid.Empty || command is null)
            return BadRequest();

        command.CardId = id;

        return await HandleResponse(command);
    }

    [HttpDelete]
    [Route("{id:guid}/access/{userId:guid}")]
    public async Task<IActionResult> RevokeCampaignCardAccess(Guid id, Guid userId)
    {
        if (id == Guid.Empty || userId == Guid.Empty)
            return BadRequest();

        return await HandleResponse(new RevokeCampaignCardAccessCommand { CardId = id, TargetUserId = userId });
    }

    [HttpPut]
    [Route("/campaigns/{id:guid}/cards/reorder")]
    public async Task<IActionResult> ReorderCampaignCards(Guid id, ReorderCampaignCardsCommand command)
    {
        if (id == Guid.Empty || command is null)
            return BadRequest();

        command.CampaignId = id;

        return await HandleResponse(command);
    }
}
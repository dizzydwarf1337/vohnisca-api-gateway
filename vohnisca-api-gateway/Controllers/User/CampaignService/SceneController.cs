using Application.Commands.User.Campaign.Card.UpdateCampaignCard;
using Application.Commands.User.Campaign.Scene.CreateSceneCard;
using Application.Commands.User.Campaign.Scene.DeleteSceneCard;
using Application.Commands.User.Campaign.Scene.RevealSceneCard;
using Application.Commands.User.Campaign.Scene.SetSceneComposition;
using Application.Core.Validation;
using Application.Queries.User.Campaign.Card.GetCampaignCard;
using Application.Queries.User.Campaign.Card.ListCampaignCards;
using Microsoft.AspNetCore.Mvc;

namespace vohnisca_api_gateway.Controllers.User.CampaignService;

// Scenes are cards of kind "scene": a table scene (a workshop map level the table will load) or a handout.
// Listing, reading and patching a scene card go through the card routes of stage 00 — the kind is the only
// difference — so this controller adds what is scene-specific: creation, the composition and the reveal.
[Route("campaign-scene-cards")]
public class SceneController : BaseController
{
    [HttpGet]
    [Route("/campaigns/{id:guid}/scene-cards")]
    public async Task<IActionResult> ListSceneCards(Guid id, [FromQuery] Guid? chapterId,
        [FromQuery] int page = 1, [FromQuery] int pageSize = 50)
    {
        if (id == Guid.Empty)
            return BadRequest();

        return await HandleResponse(new ListCampaignCardsQuery
        {
            CampaignId = id,
            Kind = CardKinds.Scene,
            ChapterId = chapterId,
            Page = page,
            PageSize = pageSize,
        });
    }

    [HttpPost]
    [Route("/campaigns/{id:guid}/scene-cards")]
    public async Task<IActionResult> CreateSceneCard(Guid id, CreateSceneCardCommand command)
    {
        if (id == Guid.Empty || command is null)
            return BadRequest();

        command.CampaignId = id;

        return await HandleResponse(command);
    }

    [HttpGet]
    [Route("{id:guid}")]
    public async Task<IActionResult> GetSceneCard(Guid id)
    {
        if (id == Guid.Empty)
            return BadRequest();

        return await HandleResponse(new GetCampaignCardQuery { CardId = id });
    }

    // The scene card is patched like any other card: title, text and meta (sceneType, mapId, levelId).
    [HttpPut]
    [Route("{id:guid}")]
    public async Task<IActionResult> UpdateSceneCard(Guid id, UpdateCampaignCardCommand command)
    {
        if (id == Guid.Empty || command is null)
            return BadRequest();

        command.CardId = id;

        return await HandleResponse(command);
    }

    [HttpPut]
    [Route("{id:guid}/revealed")]
    public async Task<IActionResult> RevealSceneCard(Guid id, RevealSceneCardCommand command)
    {
        if (id == Guid.Empty || command is null)
            return BadRequest();

        command.CardId = id;

        return await HandleResponse(command);
    }

    [HttpPut]
    [Route("{id:guid}/composition")]
    public async Task<IActionResult> SetSceneComposition(Guid id, SetSceneCompositionCommand command)
    {
        if (id == Guid.Empty || command is null)
            return BadRequest();

        command.CardId = id;

        return await HandleResponse(command);
    }

    [HttpDelete]
    [Route("{id:guid}")]
    public async Task<IActionResult> DeleteSceneCard(Guid id)
    {
        if (id == Guid.Empty)
            return BadRequest();

        return await HandleResponse(new DeleteSceneCardCommand { CardId = id });
    }
}
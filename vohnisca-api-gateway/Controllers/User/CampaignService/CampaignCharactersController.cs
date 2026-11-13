using Application.Commands.User.Campaign.Characters;
using Microsoft.AspNetCore.Mvc;

namespace vohnisca_api_gateway.Controllers.User.CampaignService;

// A campaign's characters and its milestone advancement (P-06 / P-07). Who may do what — the master or a
// co-master grants, releases and admits; members read — is decided by the campaign service.
[Route("campaigns")]
public class CampaignCharactersController : BaseController
{
    [HttpGet]
    [Route("{id:guid}/characters")]
    public async Task<IActionResult> ListCampaignCharacters(Guid id)
        => id == Guid.Empty ? BadRequest() : await HandleResponse(new ListCampaignCharactersQuery { CampaignId = id });

    [HttpPut]
    [Route("{id:guid}/hit-points-mode")]
    public async Task<IActionResult> SetHitPointsMode(Guid id, SetHitPointsModeCommand command)
    {
        if (id == Guid.Empty || command is null)
            return BadRequest();
        command.CampaignId = id;
        return await HandleResponse(command);
    }

    [HttpPost]
    [Route("{id:guid}/characters/{characterId:guid}/level-up-grant")]
    public Task<IActionResult> GrantLevelUp(Guid id, Guid characterId) => Act(id, characterId, CampaignCharacterAction.GrantLevelUp);

    [HttpPost]
    [Route("{id:guid}/characters/{characterId:guid}/release")]
    public Task<IActionResult> Release(Guid id, Guid characterId) => Act(id, characterId, CampaignCharacterAction.ReleaseCampaignCharacter);

    [HttpPost]
    [Route("{id:guid}/characters/{characterId:guid}/admit")]
    public Task<IActionResult> Admit(Guid id, Guid characterId) => Act(id, characterId, CampaignCharacterAction.AdmitCampaignCharacter);

    private async Task<IActionResult> Act(Guid id, Guid characterId, CampaignCharacterAction action)
        => id == Guid.Empty || characterId == Guid.Empty
            ? BadRequest()
            : await HandleResponse(new CampaignCharacterCommand { CampaignId = id, CharacterId = characterId, Action = action });
}

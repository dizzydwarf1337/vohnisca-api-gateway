using Application.Commands.User.Campaign.Stash.ApproveItemTake;
using Application.Commands.User.Campaign.Stash.CreateStash;
using Application.Commands.User.Campaign.Stash.GiveCoins;
using Application.Commands.User.Campaign.Stash.RejectItemTake;
using Application.Commands.User.Campaign.Stash.RequestItemTake;
using Application.Commands.User.Campaign.Stash.SetTreasury;
using Application.Queries.User.Campaign.Stash.GetStash;
using Application.Queries.User.Campaign.Stash.ListStashes;
using Microsoft.AspNetCore.Mvc;

namespace vohnisca_api_gateway.Controllers.User.CampaignService;

// Party stashes: cards of kind "stash" (each with its own treasury and contents), the players' requests to
// take something out of them, and the master's decision. The master's calls and the player's go through the
// same routes — who may do what is decided by the campaign service.
[Route("stashes")]
public class StashController : BaseController
{
    [HttpGet]
    [Route("/campaigns/{id:guid}/stashes")]
    public async Task<IActionResult> ListStashes(Guid id)
    {
        if (id == Guid.Empty)
            return BadRequest();

        return await HandleResponse(new ListStashesQuery { CampaignId = id });
    }

    [HttpPost]
    [Route("/campaigns/{id:guid}/stashes")]
    public async Task<IActionResult> CreateStash(Guid id, CreateStashCommand command)
    {
        if (id == Guid.Empty || command is null)
            return BadRequest();

        command.CampaignId = id;

        return await HandleResponse(command);
    }

    [HttpGet]
    [Route("{id:guid}")]
    public async Task<IActionResult> GetStash(Guid id)
    {
        if (id == Guid.Empty)
            return BadRequest();

        return await HandleResponse(new GetStashQuery { CardId = id });
    }

    // A player asks for something in the stash on their own character: the gateway checks the ownership
    // (the campaign service cannot see characters) and hands it the checked characterId.
    [HttpPost]
    [Route("{id:guid}/requests")]
    public async Task<IActionResult> RequestItemTake(Guid id, RequestItemTakeCommand command)
    {
        if (id == Guid.Empty || command is null)
            return BadRequest();

        command.CardId = id;

        return await HandleResponse(command);
    }

    [HttpPost]
    [Route("/stash-requests/{id:guid}/approve")]
    public async Task<IActionResult> ApproveItemTake(Guid id)
    {
        if (id == Guid.Empty)
            return BadRequest();

        return await HandleResponse(new ApproveItemTakeCommand { RequestId = id });
    }

    [HttpPost]
    [Route("/stash-requests/{id:guid}/reject")]
    public async Task<IActionResult> RejectItemTake(Guid id)
    {
        if (id == Guid.Empty)
            return BadRequest();

        return await HandleResponse(new RejectItemTakeCommand { RequestId = id });
    }

    // One route, two directions: { "operation": "add" | "spend", "coins": { "gp": 10 } }.
    [HttpPost]
    [Route("{id:guid}/treasury")]
    public async Task<IActionResult> SetTreasury(Guid id, SetTreasuryCommand command)
    {
        if (id == Guid.Empty || command is null)
            return BadRequest();

        command.CardId = id;

        return await HandleResponse(command);
    }

    [HttpPost]
    [Route("{id:guid}/treasury/give")]
    public async Task<IActionResult> GiveCoins(Guid id, GiveCoinsCommand command)
    {
        if (id == Guid.Empty || command is null)
            return BadRequest();

        command.CardId = id;

        return await HandleResponse(command);
    }
}
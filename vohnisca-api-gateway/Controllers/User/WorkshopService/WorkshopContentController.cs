using Application.Commands.User.Workshop.CreateMap;
using Application.Commands.User.Workshop.UpdateMap;
using Application.Commands.User.Workshop.SetMapVisibility;
using Application.Commands.User.Workshop.DeleteMap;
using Application.Commands.User.Workshop.RenameMapLevel;
using Application.Commands.User.Workshop.MoveMapLevel;
using Application.Commands.User.Workshop.RemoveMapLevel;
using Application.Commands.User.Workshop.CreateNpc;
using Application.Commands.User.Workshop.UpdateNpcDetails;
using Application.Commands.User.Workshop.SetNpcAbilityScores;
using Application.Commands.User.Workshop.SetNpcProfile;
using Application.Commands.User.Workshop.SetNpcImage;
using Application.Commands.User.Workshop.AddNpcAction;
using Application.Commands.User.Workshop.RemoveNpcAction;
using Application.Commands.User.Workshop.AddNpcTrait;
using Application.Commands.User.Workshop.RemoveNpcTrait;
using Application.Commands.User.Workshop.SetNpcVisibility;
using Application.Commands.User.Workshop.DeleteNpc;
using Application.Queries.User.Workshop.ListWorkshopMaps;
using Application.Queries.User.Workshop.GetWorkshopMap;
using Application.Queries.User.Workshop.ListWorkshopNpcs;
using Application.Queries.User.Workshop.GetWorkshopNpc;
using Microsoft.AspNetCore.Mvc;
using vohnisca_api_gateway.Core.Requests;

namespace vohnisca_api_gateway.Controllers.User.WorkshopService;

// Workshop maps for the table: their levels are saved from a session (sessions/{id}/scene/save-to-map)
// and loaded there (sessions/{id}/scene/map-level).
[Route("maps")]
public class MapController : BaseController
{
    [HttpGet("")]
    public Task<IActionResult> ListMaps([FromQuery] int page = 1, [FromQuery] int pageSize = 50, [FromQuery] bool mine = false)
        => HandleResponse(new ListWorkshopMapsQuery { Page = page, PageSize = pageSize, Mine = mine });

    [HttpGet("{id:guid}")]
    public Task<IActionResult> GetMap(Guid id) => HandleResponse(new GetWorkshopMapQuery { Id = id });

    [HttpPost("")]
    public Task<IActionResult> CreateMap(CreateMapCommand command) => HandleResponse(command);

    [HttpPut("{id:guid}")]
    public Task<IActionResult> UpdateMap(Guid id, UpdateMapCommand command)
    {
        command.MapId = id;
        return HandleResponse(command);
    }

    [HttpPut("{id:guid}/visibility")]
    public Task<IActionResult> SetMapVisibility(Guid id, SetMapVisibilityCommand command)
    {
        command.MapId = id;
        return HandleResponse(command);
    }

    [HttpDelete("{id:guid}")]
    public Task<IActionResult> DeleteMap(Guid id) => HandleResponse(new DeleteMapCommand { MapId = id });

    [HttpPut("{id:guid}/levels/{levelId:guid}")]
    public Task<IActionResult> RenameLevel(Guid id, Guid levelId, RenameMapLevelCommand command)
    {
        command.MapId = id;
        command.LevelId = levelId;
        return HandleResponse(command);
    }

    [HttpPut("{id:guid}/levels/{levelId:guid}/position")]
    public Task<IActionResult> MoveLevel(Guid id, Guid levelId, MoveMapLevelCommand command)
    {
        command.MapId = id;
        command.LevelId = levelId;
        return HandleResponse(command);
    }

    [HttpDelete("{id:guid}/levels/{levelId:guid}")]
    public Task<IActionResult> RemoveLevel(Guid id, Guid levelId)
        => HandleResponse(new RemoveMapLevelCommand { MapId = id, LevelId = levelId });
}

// Workshop NPCs: stat blocks the table places (sessions/{id}/scene/workshop-npcs).
[Route("npcs")]
public class NpcController : BaseController
{
    [HttpGet("")]
    public Task<IActionResult> ListNpcs([FromQuery] int page = 1, [FromQuery] int pageSize = 50, [FromQuery] bool mine = false)
        => HandleResponse(new ListWorkshopNpcsQuery { Page = page, PageSize = pageSize, Mine = mine });

    [HttpGet("{id:guid}")]
    public Task<IActionResult> GetNpc(Guid id) => HandleResponse(new GetWorkshopNpcQuery { Id = id });

    [HttpPost("")]
    public Task<IActionResult> CreateNpc(CreateNpcCommand command) => HandleResponse(command);

    [HttpPut("{id:guid}")]
    public Task<IActionResult> UpdateNpc(Guid id, UpdateNpcDetailsCommand command)
    {
        command.NpcId = id;
        return HandleResponse(command);
    }

    [HttpPut("{id:guid}/abilities")]
    public Task<IActionResult> SetAbilityScores(Guid id, SetNpcAbilityScoresCommand command)
    {
        command.NpcId = id;
        return HandleResponse(command);
    }

    [HttpPut("{id:guid}/profile")]
    public Task<IActionResult> SetProfile(Guid id, SetNpcProfileCommand command)
    {
        command.NpcId = id;
        return HandleResponse(command);
    }

    // Multipart: "file" — the portrait; without one, "remove" = true takes it off.
    [HttpPut("{id:guid}/image")]
    public async Task<IActionResult> SetImage(Guid id, [FromForm] IFormFile? file, [FromForm] bool remove = false)
    {
        var (bytes, contentType) = await WorkshopPayload.IconAsync(file);
        return await HandleResponse(new SetNpcImageCommand { NpcId = id, Image = bytes, ImageContentType = contentType, RemoveImage = remove });
    }

    [HttpPost("{id:guid}/actions")]
    public Task<IActionResult> AddAction(Guid id, AddNpcActionCommand command)
    {
        command.NpcId = id;
        return HandleResponse(command);
    }

    [HttpDelete("{id:guid}/actions/{actionId:guid}")]
    public Task<IActionResult> RemoveAction(Guid id, Guid actionId)
        => HandleResponse(new RemoveNpcActionCommand { NpcId = id, ActionId = actionId });

    [HttpPost("{id:guid}/traits")]
    public Task<IActionResult> AddTrait(Guid id, AddNpcTraitCommand command)
    {
        command.NpcId = id;
        return HandleResponse(command);
    }

    [HttpDelete("{id:guid}/traits/{traitId:guid}")]
    public Task<IActionResult> RemoveTrait(Guid id, Guid traitId)
        => HandleResponse(new RemoveNpcTraitCommand { NpcId = id, TraitId = traitId });

    [HttpPut("{id:guid}/visibility")]
    public Task<IActionResult> SetVisibility(Guid id, SetNpcVisibilityCommand command)
    {
        command.NpcId = id;
        return HandleResponse(command);
    }

    [HttpDelete("{id:guid}")]
    public Task<IActionResult> DeleteNpc(Guid id) => HandleResponse(new DeleteNpcCommand { NpcId = id });
}

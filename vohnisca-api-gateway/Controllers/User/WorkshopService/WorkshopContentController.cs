using Application.Commands.User.Workshop.ClassBuilder;
using Application.Commands.User.Workshop.CreateMap;
using Application.Commands.User.Workshop.UpdateMap;
using Application.Commands.User.Workshop.SetMapVisibility;
using Application.Commands.User.Workshop.DeleteMap;
using Application.Commands.User.Workshop.RenameMapLevel;
using Application.Commands.User.Workshop.MoveMapLevel;
using Application.Commands.User.Workshop.RemoveMapLevel;
using Application.Commands.User.Workshop.SaveMapLevel;
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
using Application.Queries.User.Workshop.GetWorkshopMapLevel;
using Application.Queries.User.Workshop.ListWorkshopNpcs;
using Application.Queries.User.Workshop.GetWorkshopNpc;
using Application.Queries.User.Workshop.RollNpcDraft;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using vohnisca_api_gateway.Core.Requests;

namespace vohnisca_api_gateway.Controllers.User.WorkshopService;

// Workshop maps for the table: their levels are saved from a session (sessions/{id}/scene/save-to-map)
// and loaded there (sessions/{id}/scene/map-level). A campaign builds its table scenes on the same maps
// through the gateway (/workshop/maps, /workshop/maps/{id}/levels) — no second map model.
[Route("maps")]
public class MapController : BaseController
{
    [HttpGet("")]
    [HttpGet("/workshop/maps")]
    public Task<IActionResult> ListMaps([FromQuery] int page = 1, [FromQuery] int pageSize = 50,
        [FromQuery] bool mine = false, [FromQuery] string? scope = null, [FromQuery] string? search = null)
        => HandleResponse(new ListWorkshopMapsQuery
        {
            Page = page,
            PageSize = pageSize,
            Mine = mine,
            Scope = scope,
            Search = search,
        });

    [HttpGet("{id:guid}")]
    [HttpGet("/workshop/maps/{id:guid}")]
    public Task<IActionResult> GetMap(Guid id) => HandleResponse(new GetWorkshopMapQuery { Id = id });

    [HttpPost("")]
    [HttpPost("/workshop/maps")]
    public Task<IActionResult> CreateMap(CreateMapCommand command) => HandleResponse(command);

    // A level saved into one of the caller's own maps: the same save the table does over the bus.
    [HttpPost("/workshop/maps/{id:guid}/levels")]
    public Task<IActionResult> SaveMapLevel(Guid id, SaveMapLevelCommand command)
    {
        command.MapId = id;
        return HandleResponse(command);
    }

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

    // A level with its scene, for the map editor (the list of maps leaves the scenes out).
    [HttpGet("{id:guid}/levels/{levelId:guid}")]
    [HttpGet("/workshop/maps/{id:guid}/levels/{levelId:guid}")]
    public Task<IActionResult> GetLevel(Guid id, Guid levelId)
        => HandleResponse(new GetWorkshopMapLevelQuery { MapId = id, LevelId = levelId });

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

// Workshop NPCs: stat blocks the table places (sessions/{id}/scene/workshop-npcs); the campaign fills its
// NPC tab from here (/workshop/npcs?scope=&search=&page= — stage 01).
[Route("npcs")]
public class NpcController : BaseController
{
    // Both prefixes reach the same list: the workshop's own (/npcs) and the one the campaign reads
    // (/workshop/npcs), so the campaign's picker is not a second implementation.
    [HttpGet("")]
    [HttpGet("/workshop/npcs")]
    public Task<IActionResult> ListNpcs([FromQuery] int page = 1, [FromQuery] int pageSize = 50,
        [FromQuery] bool mine = false, [FromQuery] string? scope = null, [FromQuery] string? search = null)
        => HandleResponse(new ListWorkshopNpcsQuery
        { Page = page, PageSize = pageSize, Mine = mine, Scope = scope, Search = search });

    // The NPC builder, two halves of one record: the bestiary stat block, or "as a character"
    // (race + class + level). The payload is the workshop's draft and the workshop validates it.
    [HttpPost("/workshop/npcs/bestiary")]
    public Task<IActionResult> CreateNpcBestiary([FromBody] JsonElement body)
        => HandleResponse(new WorkshopBuilderRequest { Method = "CreateNpcBestiary", Body = body });

    [HttpPost("/workshop/npcs/character")]
    public Task<IActionResult> CreateNpcCharacter([FromBody] JsonElement body)
        => HandleResponse(new WorkshopBuilderRequest { Method = "CreateNpcCharacter", Body = body });

    // A rolled draft for the same form: nothing is saved until the master sends it to one of the
    // two create routes above.
    [HttpPost("/workshop/npcs/draft")]
    public Task<IActionResult> RollNpcDraft(RollNpcDraftQuery query) => HandleResponse(query);

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

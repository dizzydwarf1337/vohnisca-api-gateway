using Application.Queries.User.Catalog.GetBackgroundById;
using Application.Queries.User.Catalog.GetClassById;
using Application.Queries.User.Catalog.GetFeatureById;
using Application.Queries.User.Catalog.GetItemById;
using Application.Queries.User.Catalog.GetItemInfo;
using Application.Queries.User.Catalog.GetRaceById;
using Application.Queries.User.Catalog.GetSpellById;
using Application.Queries.User.Catalog.GetSpellInfo;
using Application.Queries.User.Catalog.ListBackgrounds;
using Application.Queries.User.Catalog.ListClasses;
using Application.Queries.User.Catalog.ListFeatures;
using Application.Queries.User.Catalog.ListItems;
using Application.Queries.User.Catalog.ListRaces;
using Application.Queries.User.Catalog.ListSpells;
using System.Text.Json;
using Application.Commands.User.Workshop.CreateItem;
using Application.Commands.User.Workshop.CreateSpell;
using Application.Commands.User.Workshop.DeleteItem;
using Application.Commands.User.Workshop.DeleteSpell;
using Application.Commands.User.Workshop.SetItemVisibility;
using Application.Commands.User.Workshop.SetSpellVisibility;
using Application.Commands.User.Workshop.UpdateItem;
using Application.Commands.User.Workshop.UpdateSpell;
using Microsoft.AspNetCore.Mvc;
using vohnisca_api_gateway.Core.Requests;

namespace vohnisca_api_gateway.Controllers.User.WorkshopService;

// The rules catalog, served by the workshop service: read by the character creator and the
// management screens; the users' own spells and items are made and changed here too.
// Spell and item details windows (/info) come from the character service (how a character
// has the spell).

[Route("races")]
public class RaceController : BaseController
{
    [HttpGet("")]
    public Task<IActionResult> ListRaces([FromQuery] int page = 1, [FromQuery] int pageSize = 100)
        => HandleResponse(new ListRacesQuery { Page = page, PageSize = pageSize });

    [HttpGet("{id:guid}")]
    public Task<IActionResult> GetRace(Guid id)
        => HandleResponse(new GetRaceByIdQuery { Id = id });
}

[Route("classes")]
public class ClassController : BaseController
{
    [HttpGet("")]
    public Task<IActionResult> ListClasses([FromQuery] int page = 1, [FromQuery] int pageSize = 100)
        => HandleResponse(new ListClassesQuery { Page = page, PageSize = pageSize });

    [HttpGet("{id:guid}")]
    public Task<IActionResult> GetClass(Guid id)
        => HandleResponse(new GetClassByIdQuery { Id = id });
}

[Route("backgrounds")]
public class BackgroundController : BaseController
{
    [HttpGet("")]
    public Task<IActionResult> ListBackgrounds([FromQuery] int page = 1, [FromQuery] int pageSize = 100)
        => HandleResponse(new ListBackgroundsQuery { Page = page, PageSize = pageSize });

    [HttpGet("{id:guid}")]
    public Task<IActionResult> GetBackground(Guid id)
        => HandleResponse(new GetBackgroundByIdQuery { Id = id });
}

[Route("features")]
public class FeatureController : BaseController
{
    [HttpGet("")]
    public Task<IActionResult> ListFeatures(
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 100,
        [FromQuery] bool onlySelectableAsFeat = false)
        => HandleResponse(new ListFeaturesQuery
        { Page = page, PageSize = pageSize, OnlySelectableAsFeat = onlySelectableAsFeat });

    [HttpGet("{id:guid}")]
    public Task<IActionResult> GetFeature(Guid id)
        => HandleResponse(new GetFeatureByIdQuery { Id = id });
}

[Route("items")]
public class ItemController : BaseController
{
    // Multipart: "payload" carries the item JSON, "file" an optional icon.
    [HttpPost("")]
    public async Task<IActionResult> CreateItem([FromForm] string payload, [FromForm] IFormFile? file)
    {
        if (WorkshopPayload.Read<CreateWorkshopItemCommand>(payload) is not { } command) return BadRequest();
        (command.Image, command.ImageContentType) = await WorkshopPayload.IconAsync(file);
        return await HandleResponse(command);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateItem(Guid id, [FromForm] string payload, [FromForm] IFormFile? file)
    {
        if (WorkshopPayload.Read<UpdateWorkshopItemCommand>(payload) is not { } command) return BadRequest();
        command.ItemId = id;
        (command.Image, command.ImageContentType) = await WorkshopPayload.IconAsync(file);
        return await HandleResponse(command);
    }

    [HttpPut("{id:guid}/visibility")]
    public Task<IActionResult> SetItemVisibility(Guid id, SetWorkshopItemVisibilityCommand command)
    {
        command.ItemId = id;
        return HandleResponse(command);
    }

    [HttpDelete("{id:guid}")]
    public Task<IActionResult> DeleteItem(Guid id)
        => HandleResponse(new DeleteWorkshopItemCommand { ItemId = id });

    [HttpGet("")]
    public Task<IActionResult> ListItems([FromQuery] int page = 1, [FromQuery] int pageSize = 100)
        => HandleResponse(new ListItemsQuery { Page = page, PageSize = pageSize });

    [HttpGet("{id:guid}")]
    public Task<IActionResult> GetItem(Guid id)
        => HandleResponse(new GetItemByIdQuery { Id = id });

    [HttpGet("{id:guid}/info")]
    public Task<IActionResult> GetItemInfo(Guid id)
        => HandleResponse(new GetItemInfoQuery { ItemId = id });
}

[Route("spells")]
public class SpellController : BaseController
{
    // Multipart: "payload" carries the spell JSON, "file" an optional icon.
    [HttpPost("")]
    public async Task<IActionResult> CreateSpell([FromForm] string payload, [FromForm] IFormFile? file)
    {
        if (WorkshopPayload.Read<CreateWorkshopSpellCommand>(payload) is not { } command) return BadRequest();
        (command.Image, command.ImageContentType) = await WorkshopPayload.IconAsync(file);
        return await HandleResponse(command);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateSpell(Guid id, [FromForm] string payload, [FromForm] IFormFile? file)
    {
        if (WorkshopPayload.Read<UpdateWorkshopSpellCommand>(payload) is not { } command) return BadRequest();
        command.SpellId = id;
        (command.Image, command.ImageContentType) = await WorkshopPayload.IconAsync(file);
        return await HandleResponse(command);
    }

    [HttpPut("{id:guid}/visibility")]
    public Task<IActionResult> SetSpellVisibility(Guid id, SetWorkshopSpellVisibilityCommand command)
    {
        command.SpellId = id;
        return HandleResponse(command);
    }

    [HttpDelete("{id:guid}")]
    public Task<IActionResult> DeleteSpell(Guid id)
        => HandleResponse(new DeleteWorkshopSpellCommand { SpellId = id });

    [HttpGet("")]
    public Task<IActionResult> ListSpells(
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 100,
        [FromQuery] int? level = null)
        => HandleResponse(new ListSpellsQuery { Page = page, PageSize = pageSize, Level = level });

    [HttpGet("{id:guid}")]
    public Task<IActionResult> GetSpell(Guid id)
        => HandleResponse(new GetSpellByIdQuery { Id = id });

    // characterId: whose sheet it's opened from (how the character has the spell).
    [HttpGet("{id:guid}/info")]
    public Task<IActionResult> GetSpellInfo(Guid id, [FromQuery] Guid? characterId = null)
        => HandleResponse(new GetSpellInfoQuery { SpellId = id, CharacterId = characterId });
}

// The JSON part of a multipart workshop request, and its optional icon.
internal static class WorkshopPayload
{
    private static readonly JsonSerializerOptions Json = new() { PropertyNameCaseInsensitive = true };

    public static T? Read<T>(string payload) where T : class
    {
        try
        {
            return JsonSerializer.Deserialize<T>(payload, Json);
        }
        catch (JsonException)
        {
            return null;
        }
    }

    public static Task<(byte[]? Bytes, string? ContentType)> IconAsync(IFormFile? file)
        => GetFileContent.GetAsync(file, [FileType.ImageJpeg, FileType.ImagePng, FileType.ImageWebp, FileType.ImageGif]);
}

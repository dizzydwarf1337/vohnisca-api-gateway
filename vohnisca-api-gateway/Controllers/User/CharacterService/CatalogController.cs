using Application.Queries.User.Catalog.GetBackgroundById;
using Application.Queries.User.Catalog.GetClassById;
using Application.Queries.User.Catalog.GetFeatureById;
using Application.Queries.User.Catalog.GetItemById;
using Application.Queries.User.Catalog.GetRaceById;
using Application.Queries.User.Catalog.GetSpellById;
using Application.Queries.User.Catalog.ListBackgrounds;
using Application.Queries.User.Catalog.ListClasses;
using Application.Queries.User.Catalog.ListFeatures;
using Application.Queries.User.Catalog.ListItems;
using Application.Queries.User.Catalog.ListRaces;
using Application.Queries.User.Catalog.ListSpells;
using Microsoft.AspNetCore.Mvc;

namespace vohnisca_api_gateway.Controllers.User.CharacterService;

// Read-only catalog (rules content) served by the character service, used by the
// character creator and the management screens.

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
    [HttpGet("")]
    public Task<IActionResult> ListItems([FromQuery] int page = 1, [FromQuery] int pageSize = 100)
        => HandleResponse(new ListItemsQuery { Page = page, PageSize = pageSize });

    [HttpGet("{id:guid}")]
    public Task<IActionResult> GetItem(Guid id)
        => HandleResponse(new GetItemByIdQuery { Id = id });
}

[Route("spells")]
public class SpellController : BaseController
{
    [HttpGet("")]
    public Task<IActionResult> ListSpells(
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 100,
        [FromQuery] int? level = null)
        => HandleResponse(new ListSpellsQuery { Page = page, PageSize = pageSize, Level = level });

    [HttpGet("{id:guid}")]
    public Task<IActionResult> GetSpell(Guid id)
        => HandleResponse(new GetSpellByIdQuery { Id = id });
}

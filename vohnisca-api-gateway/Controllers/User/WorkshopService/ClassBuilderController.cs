using System.Text.Json;
using System.Text.Json.Nodes;
using Application.Commands.User.Workshop.ClassBuilder;
using Microsoft.AspNetCore.Mvc;

namespace vohnisca_api_gateway.Controllers.User.WorkshopService;

// The class builder in the workshop: users' classes and the subclasses made for any class,
// private until published; search by scope (available, system, mine, global, library, all);
// the user's library (on/off: what creation and level up offer); the mechanics a feature can
// work as. Bodies pass through to the workshop (WorkshopBuilderRequest).
[Route("workshop")]
public class ClassBuilderController : BaseController
{
    private Task<IActionResult> Call(string method, object body)
        => HandleResponse(new WorkshopBuilderRequest { Method = method, Body = JsonSerializer.SerializeToElement(body) });

    private Task<IActionResult> Call(string method, JsonElement body, params (string Key, object? Value)[] more)
    {
        var node = body.ValueKind == JsonValueKind.Object ? JsonNode.Parse(body.GetRawText())!.AsObject() : new JsonObject();
        foreach (var (key, value) in more) node[key] = JsonSerializer.SerializeToNode(value);
        return HandleResponse(new WorkshopBuilderRequest { Method = method, Body = JsonSerializer.SerializeToElement(node) });
    }

    private static object Page(int page, int pageSize) => new { page, pageSize };

    // ---- Classes ----

    [HttpGet("classes")]
    public Task<IActionResult> ListClasses([FromQuery] string? scope, [FromQuery] string? search, [FromQuery] int page = 1, [FromQuery] int pageSize = 20)
        => Call("ListClasses", new { scope, search, pagination = Page(page, pageSize) });

    [HttpGet("classes/{id:guid}")]
    public Task<IActionResult> GetClass(Guid id) => Call("GetClassById", new { id });

    [HttpPost("classes")]
    public Task<IActionResult> CreateClass([FromBody] JsonElement body) => Call("CreateClass", body);

    [HttpPut("classes/{id:guid}")]
    public Task<IActionResult> UpdateClass(Guid id, [FromBody] JsonElement body) => Call("UpdateClass", body, ("id", id));

    [HttpPut("classes/{id:guid}/visibility")]
    public Task<IActionResult> SetClassVisibility(Guid id, [FromBody] JsonElement body) => Call("SetClassVisibility", body, ("id", id));

    [HttpDelete("classes/{id:guid}")]
    public Task<IActionResult> DeleteClass(Guid id) => Call("DeleteClass", new { id });

    // ---- Subclasses ----

    [HttpGet("subclasses")]
    public Task<IActionResult> ListSubclasses([FromQuery] Guid? classId, [FromQuery] string? scope, [FromQuery] string? search,
        [FromQuery] int page = 1, [FromQuery] int pageSize = 20)
        => Call("ListSubclasses", new { classId, scope, search, pagination = Page(page, pageSize) });

    [HttpGet("subclasses/{id:guid}")]
    public Task<IActionResult> GetSubclass(Guid id) => Call("GetSubclassById", new { id });

    [HttpPost("subclasses")]
    public Task<IActionResult> CreateSubclass([FromBody] JsonElement body) => Call("CreateSubclass", body);

    [HttpPut("subclasses/{id:guid}")]
    public Task<IActionResult> UpdateSubclass(Guid id, [FromBody] JsonElement body) => Call("UpdateSubclass", body, ("id", id));

    [HttpPut("subclasses/{id:guid}/visibility")]
    public Task<IActionResult> SetSubclassVisibility(Guid id, [FromBody] JsonElement body) => Call("SetSubclassVisibility", body, ("id", id));

    [HttpDelete("subclasses/{id:guid}")]
    public Task<IActionResult> DeleteSubclass(Guid id) => Call("DeleteSubclass", new { id });

    // ---- Library ----

    [HttpGet("library")]
    public Task<IActionResult> ListLibrary([FromQuery] string? kind, [FromQuery] int page = 1, [FromQuery] int pageSize = 50)
        => Call("ListLibrary", new { kind, pagination = Page(page, pageSize) });

    [HttpPost("library")]
    public Task<IActionResult> AddToLibrary([FromBody] JsonElement body) => Call("AddToLibrary", body);

    [HttpPut("library/{kind}/{contentId:guid}")]
    public Task<IActionResult> SetLibraryEnabled(string kind, Guid contentId, [FromBody] JsonElement body)
        => Call("SetLibraryEnabled", body, ("kind", kind), ("contentId", contentId));

    [HttpDelete("library/{kind}/{contentId:guid}")]
    public Task<IActionResult> RemoveFromLibrary(string kind, Guid contentId) => Call("RemoveFromLibrary", new { kind, contentId });

    [HttpGet("mechanics")]
    public Task<IActionResult> ListMechanics() => Call("ListFeatureMechanics", new { });
}

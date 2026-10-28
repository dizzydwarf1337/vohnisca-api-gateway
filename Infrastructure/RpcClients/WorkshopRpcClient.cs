using Application.Commands.User.Workshop.CreateItem;
using Application.Commands.User.Workshop.CreateSpell;
using Application.Commands.User.Workshop.DeleteItem;
using Application.Commands.User.Workshop.DeleteSpell;
using Application.Commands.User.Workshop.SetItemVisibility;
using Application.Commands.User.Workshop.SetSpellVisibility;
using Application.Commands.User.Workshop.UpdateItem;
using Application.Commands.User.Workshop.UpdateSpell;
using Application.Core.Responses;
using Application.Interfaces.RpcClients;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.RpcClients;

// The workshop service is a .NET JSON-RPC service like the character service: methods by
// name at the root, parameters under "request" (DotnetRpcClient).
public class WorkshopRpcClient : DotnetRpcClient, IWorkshopRpcClient
{
    public WorkshopRpcClient(IConfiguration configuration)
        : base(configuration["RpcServices:WorkshopService"] ?? throw new Exception("WorkshopService URI not set")) { }

    // --- Catalog reads ---
    public Task<RpcResult<PaginationResponse<RaceListRow>>> ListRaces(int page, int pageSize, string token)
        => SendData<PaginationResponse<RaceListRow>>("ListRaces", Paged(page, pageSize), token);

    public Task<RpcResult<RaceDetail>> GetRaceById(Guid id, string token)
        => SendData<RaceDetail>("GetRaceById", new { Id = id }, token);

    public Task<RpcResult<PaginationResponse<ClassListRow>>> ListClasses(int page, int pageSize, string token)
        => SendData<PaginationResponse<ClassListRow>>("ListClasses", Paged(page, pageSize), token);

    public Task<RpcResult<ClassDetail>> GetClassById(Guid id, string token)
        => SendData<ClassDetail>("GetClassById", new { Id = id }, token);

    public Task<RpcResult<PaginationResponse<BackgroundListRow>>> ListBackgrounds(int page, int pageSize, string token)
        => SendData<PaginationResponse<BackgroundListRow>>("ListBackgrounds", Paged(page, pageSize), token);

    public Task<RpcResult<BackgroundDetail>> GetBackgroundById(Guid id, string token)
        => SendData<BackgroundDetail>("GetBackgroundById", new { Id = id }, token);

    public Task<RpcResult<PaginationResponse<FeatureListRow>>> ListFeatures(int page, int pageSize, bool onlySelectableAsFeat, string token)
        => SendData<PaginationResponse<FeatureListRow>>(
            "ListFeatures",
            new { Pagination = new { Page = page, PageSize = pageSize }, OnlySelectableAsFeat = onlySelectableAsFeat },
            token);

    public Task<RpcResult<FeatureDetail>> GetFeatureById(Guid id, string token)
        => SendData<FeatureDetail>("GetFeatureById", new { Id = id }, token);

    public Task<RpcResult<PaginationResponse<ItemListRow>>> ListItems(int page, int pageSize, string token)
        => SendData<PaginationResponse<ItemListRow>>("ListItems", Paged(page, pageSize), token);

    public Task<RpcResult<ItemDetail>> GetItemById(Guid id, string token)
        => SendData<ItemDetail>("GetItemById", new { Id = id }, token);

    public Task<RpcResult<PaginationResponse<SpellListRow>>> ListSpells(int page, int pageSize, int? level, string token)
        => SendData<PaginationResponse<SpellListRow>>(
            "ListSpells",
            new { Pagination = new { Page = page, PageSize = pageSize }, Level = level },
            token);

    public Task<RpcResult<SpellDetail>> GetSpellById(Guid id, string token)
        => SendData<SpellDetail>("GetSpellById", new { Id = id }, token);


    // --- The users' own spells and items ---
    public Task<RpcResult<CreatedContent>> CreateSpell(CreateWorkshopSpellCommand request, string token)
        => SendData<CreatedContent>("CreateSpell", request, token);

    public Task<RpcResult<bool>> UpdateSpell(UpdateWorkshopSpellCommand request, string token)
        => SendCommand("UpdateSpell", request, token);

    public Task<RpcResult<bool>> SetSpellVisibility(SetWorkshopSpellVisibilityCommand request, string token)
        => SendCommand("SetSpellVisibility", request, token);

    public Task<RpcResult<bool>> DeleteSpell(DeleteWorkshopSpellCommand request, string token)
        => SendCommand("DeleteSpell", request, token);

    public Task<RpcResult<CreatedContent>> CreateItem(CreateWorkshopItemCommand request, string token)
        => SendData<CreatedContent>("CreateItem", request, token);

    public Task<RpcResult<bool>> UpdateItem(UpdateWorkshopItemCommand request, string token)
        => SendCommand("UpdateItem", request, token);

    public Task<RpcResult<bool>> SetItemVisibility(SetWorkshopItemVisibilityCommand request, string token)
        => SendCommand("SetItemVisibility", request, token);

    public Task<RpcResult<bool>> DeleteItem(DeleteWorkshopItemCommand request, string token)
        => SendCommand("DeleteItem", request, token);

    private static object Paged(int page, int pageSize)
        => new { Pagination = new { Page = page, PageSize = pageSize } };
}

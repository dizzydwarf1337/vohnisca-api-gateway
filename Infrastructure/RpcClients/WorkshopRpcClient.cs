using Application.Commands.User.Workshop.AddNpcAction;
using Application.Commands.User.Workshop.AddNpcTrait;
using Application.Commands.User.Workshop.CreateMap;
using Application.Commands.User.Workshop.CreateNpc;
using Application.Commands.User.Workshop.DeleteMap;
using Application.Commands.User.Workshop.DeleteNpc;
using Application.Commands.User.Workshop.MoveMapLevel;
using Application.Commands.User.Workshop.RemoveMapLevel;
using Application.Commands.User.Workshop.RemoveNpcAction;
using Application.Commands.User.Workshop.RemoveNpcTrait;
using Application.Commands.User.Workshop.RenameMapLevel;
using Application.Commands.User.Workshop.SetMapVisibility;
using Application.Commands.User.Workshop.SetNpcAbilityScores;
using Application.Commands.User.Workshop.SetNpcImage;
using Application.Commands.User.Workshop.SetNpcProfile;
using Application.Commands.User.Workshop.SetNpcVisibility;
using Application.Commands.User.Workshop.UpdateMap;
using Application.Commands.User.Workshop.UpdateNpcDetails;
using Application.Queries.User.Workshop.GetWorkshopMap;
using Application.Queries.User.Workshop.GetWorkshopNpc;
using Application.Queries.User.Workshop.ListWorkshopMaps;
using Application.Queries.User.Workshop.ListWorkshopNpcs;
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

    // --- Maps and NPCs ---
    public Task<RpcResult<CreatedContent>> CreateMap(CreateMapCommand request, string token)
        => SendData<CreatedContent>("CreateMap", request, token);

    public Task<RpcResult<bool>> UpdateMap(UpdateMapCommand request, string token)
        => SendCommand("UpdateMap", request, token);

    public Task<RpcResult<bool>> SetMapVisibility(SetMapVisibilityCommand request, string token)
        => SendCommand("SetMapVisibility", request, token);

    public Task<RpcResult<bool>> DeleteMap(DeleteMapCommand request, string token)
        => SendCommand("DeleteMap", request, token);

    public Task<RpcResult<bool>> RenameMapLevel(RenameMapLevelCommand request, string token)
        => SendCommand("RenameMapLevel", request, token);

    public Task<RpcResult<bool>> MoveMapLevel(MoveMapLevelCommand request, string token)
        => SendCommand("MoveMapLevel", request, token);

    public Task<RpcResult<bool>> RemoveMapLevel(RemoveMapLevelCommand request, string token)
        => SendCommand("RemoveMapLevel", request, token);

    public Task<RpcResult<CreatedContent>> CreateNpc(CreateNpcCommand request, string token)
        => SendData<CreatedContent>("CreateNpc", request, token);

    public Task<RpcResult<bool>> UpdateNpcDetails(UpdateNpcDetailsCommand request, string token)
        => SendCommand("UpdateNpcDetails", request, token);

    public Task<RpcResult<bool>> SetNpcAbilityScores(SetNpcAbilityScoresCommand request, string token)
        => SendCommand("SetNpcAbilityScores", request, token);

    public Task<RpcResult<bool>> SetNpcProfile(SetNpcProfileCommand request, string token)
        => SendCommand("SetNpcProfile", request, token);

    public Task<RpcResult<bool>> SetNpcImage(SetNpcImageCommand request, string token)
        => SendCommand("SetNpcImage", request, token);

    public Task<RpcResult<NpcActionAdded>> AddNpcAction(AddNpcActionCommand request, string token)
        => SendData<NpcActionAdded>("AddNpcAction", request, token);

    public Task<RpcResult<bool>> RemoveNpcAction(RemoveNpcActionCommand request, string token)
        => SendCommand("RemoveNpcAction", request, token);

    public Task<RpcResult<NpcTraitAdded>> AddNpcTrait(AddNpcTraitCommand request, string token)
        => SendData<NpcTraitAdded>("AddNpcTrait", request, token);

    public Task<RpcResult<bool>> RemoveNpcTrait(RemoveNpcTraitCommand request, string token)
        => SendCommand("RemoveNpcTrait", request, token);

    public Task<RpcResult<bool>> SetNpcVisibility(SetNpcVisibilityCommand request, string token)
        => SendCommand("SetNpcVisibility", request, token);

    public Task<RpcResult<bool>> DeleteNpc(DeleteNpcCommand request, string token)
        => SendCommand("DeleteNpc", request, token);

    public Task<RpcResult<PaginationResponse<WorkshopMapRow>>> ListWorkshopMaps(ListWorkshopMapsQuery request, string token)
        => SendData<PaginationResponse<WorkshopMapRow>>("ListMaps", new { Pagination = new { Page = request.Page, PageSize = request.PageSize }, Mine = request.Mine }, token);

    public Task<RpcResult<WorkshopMapRow>> GetWorkshopMap(GetWorkshopMapQuery request, string token)
        => SendData<WorkshopMapRow>("GetMapById", new { Id = request.Id }, token);

    public Task<RpcResult<PaginationResponse<WorkshopNpcRow>>> ListWorkshopNpcs(ListWorkshopNpcsQuery request, string token)
        => SendData<PaginationResponse<WorkshopNpcRow>>("ListNpcs", new { Pagination = new { Page = request.Page, PageSize = request.PageSize }, Mine = request.Mine }, token);

    public Task<RpcResult<WorkshopNpcDetail>> GetWorkshopNpc(GetWorkshopNpcQuery request, string token)
        => SendData<WorkshopNpcDetail>("GetNpcById", new { Id = request.Id }, token);

    private static object Paged(int page, int pageSize)
        => new { Pagination = new { Page = page, PageSize = pageSize } };
}

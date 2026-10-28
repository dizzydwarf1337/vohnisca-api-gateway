using Application.Commands.User.Workshop.CreateItem;
using Application.Commands.User.Workshop.CreateSpell;
using Application.Commands.User.Workshop.DeleteItem;
using Application.Commands.User.Workshop.DeleteSpell;
using Application.Commands.User.Workshop.SetItemVisibility;
using Application.Commands.User.Workshop.SetSpellVisibility;
using Application.Commands.User.Workshop.UpdateItem;
using Application.Commands.User.Workshop.UpdateSpell;
using Application.Core.Responses;

namespace Application.Interfaces.RpcClients;

// The workshop service: the rules catalog (races, classes, backgrounds, features, items,
// spells) and the users' own spells and items.
public interface IWorkshopRpcClient
{
    // Catalog reads (the character creator, the management screens)
    Task<RpcResult<PaginationResponse<RaceListRow>>> ListRaces(int page, int pageSize, string token);
    Task<RpcResult<RaceDetail>> GetRaceById(Guid id, string token);
    Task<RpcResult<PaginationResponse<ClassListRow>>> ListClasses(int page, int pageSize, string token);
    Task<RpcResult<ClassDetail>> GetClassById(Guid id, string token);
    Task<RpcResult<PaginationResponse<BackgroundListRow>>> ListBackgrounds(int page, int pageSize, string token);
    Task<RpcResult<BackgroundDetail>> GetBackgroundById(Guid id, string token);
    Task<RpcResult<PaginationResponse<FeatureListRow>>> ListFeatures(int page, int pageSize, bool onlySelectableAsFeat, string token);
    Task<RpcResult<FeatureDetail>> GetFeatureById(Guid id, string token);
    Task<RpcResult<PaginationResponse<ItemListRow>>> ListItems(int page, int pageSize, string token);
    Task<RpcResult<ItemDetail>> GetItemById(Guid id, string token);
    Task<RpcResult<PaginationResponse<SpellListRow>>> ListSpells(int page, int pageSize, int? level, string token);
    Task<RpcResult<SpellDetail>> GetSpellById(Guid id, string token);

    // The users' own spells and items
    Task<RpcResult<CreatedContent>> CreateSpell(CreateWorkshopSpellCommand request, string token);
    Task<RpcResult<bool>> UpdateSpell(UpdateWorkshopSpellCommand request, string token);
    Task<RpcResult<bool>> SetSpellVisibility(SetWorkshopSpellVisibilityCommand request, string token);
    Task<RpcResult<bool>> DeleteSpell(DeleteWorkshopSpellCommand request, string token);
    Task<RpcResult<CreatedContent>> CreateItem(CreateWorkshopItemCommand request, string token);
    Task<RpcResult<bool>> UpdateItem(UpdateWorkshopItemCommand request, string token);
    Task<RpcResult<bool>> SetItemVisibility(SetWorkshopItemVisibilityCommand request, string token);
    Task<RpcResult<bool>> DeleteItem(DeleteWorkshopItemCommand request, string token);
}

public record CreatedContent(Guid Id);

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

    // Maps and NPCs
    Task<RpcResult<CreatedContent>> CreateMap(CreateMapCommand request, string token);
    Task<RpcResult<bool>> UpdateMap(UpdateMapCommand request, string token);
    Task<RpcResult<bool>> SetMapVisibility(SetMapVisibilityCommand request, string token);
    Task<RpcResult<bool>> DeleteMap(DeleteMapCommand request, string token);
    Task<RpcResult<bool>> RenameMapLevel(RenameMapLevelCommand request, string token);
    Task<RpcResult<bool>> MoveMapLevel(MoveMapLevelCommand request, string token);
    Task<RpcResult<bool>> RemoveMapLevel(RemoveMapLevelCommand request, string token);
    Task<RpcResult<CreatedContent>> CreateNpc(CreateNpcCommand request, string token);
    Task<RpcResult<bool>> UpdateNpcDetails(UpdateNpcDetailsCommand request, string token);
    Task<RpcResult<bool>> SetNpcAbilityScores(SetNpcAbilityScoresCommand request, string token);
    Task<RpcResult<bool>> SetNpcProfile(SetNpcProfileCommand request, string token);
    Task<RpcResult<bool>> SetNpcImage(SetNpcImageCommand request, string token);
    Task<RpcResult<NpcActionAdded>> AddNpcAction(AddNpcActionCommand request, string token);
    Task<RpcResult<bool>> RemoveNpcAction(RemoveNpcActionCommand request, string token);
    Task<RpcResult<NpcTraitAdded>> AddNpcTrait(AddNpcTraitCommand request, string token);
    Task<RpcResult<bool>> RemoveNpcTrait(RemoveNpcTraitCommand request, string token);
    Task<RpcResult<bool>> SetNpcVisibility(SetNpcVisibilityCommand request, string token);
    Task<RpcResult<bool>> DeleteNpc(DeleteNpcCommand request, string token);
    Task<RpcResult<PaginationResponse<WorkshopMapRow>>> ListWorkshopMaps(ListWorkshopMapsQuery request, string token);
    Task<RpcResult<WorkshopMapRow>> GetWorkshopMap(GetWorkshopMapQuery request, string token);
    Task<RpcResult<PaginationResponse<WorkshopNpcRow>>> ListWorkshopNpcs(ListWorkshopNpcsQuery request, string token);
    Task<RpcResult<WorkshopNpcDetail>> GetWorkshopNpc(GetWorkshopNpcQuery request, string token);
}

public record CreatedContent(Guid Id);

public record NpcActionAdded(Guid ActionId);

public record NpcTraitAdded(Guid TraitId);

// A map with its levels (Visibility by name; IsMine: the viewer's own).
public record WorkshopMapRow(Guid Id, string Name, string Description, string Visibility, OwnerRef? Owner, bool IsMine, List<WorkshopMapLevel> Levels);

public record WorkshopMapLevel(Guid Id, string Name, int Order, int Cols, int Rows, string ImageUrl, DateTime SavedAt);

public record WorkshopNpcRow(Guid Id, string Name, string CreatureType, double ChallengeRating, string Visibility, OwnerRef? Owner, string? ImagePath);

public record WorkshopNpcTrait(Guid Id, string Name, string Description);

public record WorkshopNpcAction(Guid Id, string Name, string Description, int? AttackBonus, int? DamageDiceCount, string? DamageDiceType,
    string? DamageType, int? DamageBonus, string? Range);

public record WorkshopNpcDetail(
    Guid Id, string Name, string Description, string Source, string CreatureType, string Size, string Alignment,
    int ArmorClass, int MaxHitPoints, string HitDiceFormula, int Speed, Dictionary<string, int> SpecialSpeeds,
    double ChallengeRating, int ProficiencyBonus, Dictionary<string, int> AbilityScores, List<string> SavingThrowProficiencies,
    Dictionary<string, int> SkillBonuses, List<string> DamageResistances, List<string> DamageImmunities,
    List<string> DamageVulnerabilities, List<string> ConditionImmunities, Dictionary<string, int> Senses,
    List<string> Languages, List<WorkshopNpcTrait> Traits, List<WorkshopNpcAction> Actions, OwnerRef? Owner,
    string Visibility, string? ImagePath);

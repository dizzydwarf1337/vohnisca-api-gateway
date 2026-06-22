using Application.Commands.User.Character.AddClassToCharacter;
using Application.Commands.User.Character.AddFeatureToCharacter;
using Application.Commands.User.Character.AddItemToCharacter;
using Application.Commands.User.Character.ApplyAbilityScoreImprovement;
using Application.Commands.User.Character.AttuneItem;
using Application.Commands.User.Character.ChangeCharacterSubRace;
using Application.Commands.User.Character.ChooseSubclass;
using Application.Commands.User.Character.CreateCharacter;
using Application.Commands.User.Character.DeleteCharacter;
using Application.Commands.User.Character.EquipItem;
using Application.Commands.User.Character.LearnSpell;
using Application.Commands.User.Character.LevelUpCharacter;
using Application.Commands.User.Character.PrepareSpell;
using Application.Commands.User.Character.RemoveItemFromCharacter;
using Application.Commands.User.Character.RenameCharacter;
using Application.Commands.User.Character.RevokeCharacterShare;
using Application.Commands.User.Character.SetCharacterAbilityScores;
using Application.Commands.User.Character.ShareCharacter;
using Application.Commands.User.Character.UnequipItem;
using Application.Commands.User.Character.UnlearnSpell;
using Application.Commands.User.Character.UnprepareSpell;
using Application.Core.Responses;

namespace Application.Interfaces.RpcClients;

// Talks to the (.NET / JSON-RPC) character service. Methods are addressed by name on
// the service's root route, mirroring how IUserRpcClient talks to the user service.
public interface ICharacterRpcClient
{
    // Characters
    Task<RpcResult<CreateCharacterData>> CreateCharacter(CreateCharacterCommand request, string token);
    Task<RpcResult<bool>> RenameCharacter(RenameCharacterCommand request, string token);
    Task<RpcResult<bool>> DeleteCharacter(DeleteCharacterCommand request, string token);
    Task<RpcResult<CharacterSheetData>> GetCharacterById(Guid id, string token);
    Task<RpcResult<PaginationResponse<CharacterListRow>>> ListCharacters(int page, int pageSize, string token);
    Task<RpcResult<List<SharedCharacterRow>>> GetSharedCharactersList(string token);

    // Progression
    Task<RpcResult<bool>> AddClassToCharacter(AddClassToCharacterCommand request, string token);
    Task<RpcResult<bool>> ChooseSubclass(ChooseSubclassCommand request, string token);
    Task<RpcResult<bool>> LevelUpCharacter(LevelUpCharacterCommand request, string token);
    Task<RpcResult<bool>> ApplyAbilityScoreImprovement(ApplyAbilityScoreImprovementCommand request, string token);
    Task<RpcResult<bool>> AddFeatureToCharacter(AddFeatureToCharacterCommand request, string token);
    Task<RpcResult<bool>> ChangeCharacterSubRace(ChangeCharacterSubRaceCommand request, string token);
    Task<RpcResult<bool>> SetCharacterAbilityScores(SetCharacterAbilityScoresCommand request, string token);

    // Inventory
    Task<RpcResult<bool>> AddItemToCharacter(AddItemToCharacterCommand request, string token);
    Task<RpcResult<bool>> RemoveItemFromCharacter(RemoveItemFromCharacterCommand request, string token);
    Task<RpcResult<bool>> EquipItem(EquipItemCommand request, string token);
    Task<RpcResult<bool>> UnequipItem(UnequipItemCommand request, string token);
    Task<RpcResult<bool>> AttuneItem(AttuneItemCommand request, string token);

    // Spells
    Task<RpcResult<bool>> LearnSpell(LearnSpellCommand request, string token);
    Task<RpcResult<bool>> UnlearnSpell(UnlearnSpellCommand request, string token);
    Task<RpcResult<bool>> PrepareSpell(PrepareSpellCommand request, string token);
    Task<RpcResult<bool>> UnprepareSpell(UnprepareSpellCommand request, string token);

    // Sharing
    Task<RpcResult<bool>> ShareCharacter(ShareCharacterCommand request, string token);
    Task<RpcResult<bool>> RevokeCharacterShare(RevokeCharacterShareCommand request, string token);

    // Catalog reads (needed by the character creator and the management screens)
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
}

// Wraps the character service's RpcResponse<T> envelope ({ IsSuccess, Data, Error, StatusCode }).
public record RpcDataResponse<T>(T Data, bool IsSuccess = true, string? Error = null, int StatusCode = 200)
    : DefaultRpcResponse(IsSuccess, Error, StatusCode);

// ---- Shared catalog DTOs ----
public record OwnerRef(Guid Id, string UserName, string ProfilePicturePath);
public record CatalogFeatureRef(Guid Id, string Name, string Description);
public record CatalogItemDto(Guid Id, string Name, string Description, double Weight, int ValueInCopper, string Rarity, string? ImagePath);

// ---- Characters ----
public record CreateCharacterData(Guid Id);

public record CharRaceRef(Guid Id, string Name);
public record CharBackgroundRef(Guid Id, string Name);

public record CharacterListRow(Guid Id, string Name, CharRaceRef Race, CharBackgroundRef Background, int TotalLevel);

public record SharedCharacterRow(
    Guid CharacterId,
    string CharacterName,
    int TotalLevel,
    string Access,
    Guid OwnerId,
    string OwnerUserName,
    string OwnerProfilePicturePath);

// ---- Character sheet ----
public record SheetSubClassRef(Guid Id, string Name);
public record SheetClassRow(Guid ClassId, string Name, string IconUrl, int Level, SheetSubClassRef? SubClass);
public record SheetHitDiceRow(string DiceType, int Total, int Used);
public record SheetSkillRow(string Skill, string Proficiency, int Modifier);
public record SheetAbilityRow(
    string Ability,
    int Value,
    int Modifier,
    bool SavingThrowProficient,
    int SavingThrowModifier,
    SheetSkillRow[] Skills);
public record SheetFeatureRow(Guid Id, string Name, string Type);
public record SheetSpellRow(Guid Id, string Name, int Level, string School, string? ImagePath);
public record SheetSpellcastingRow(
    Guid ClassId,
    string ClassName,
    string Type,
    string Ability,
    int SaveDC,
    int AttackBonus,
    int KnownCantrips,
    int MaxPreparedSpells,
    int MaxKnownSpells,
    Dictionary<int, int> TotalSlots,
    SheetSpellRow[] KnownSpells,
    SheetSpellRow[] PreparedSpells);
public record SheetMoneyRow(int Copper, int Silver, int Electrum, int Gold, int Platinum);
public record SheetItemRow(
    Guid ItemId,
    string Name,
    string Description,
    double Weight,
    int ValueInCopper,
    string Rarity,
    string? ImagePath,
    int Quantity,
    bool IsEquipped,
    bool IsAttuned);
public record SheetItemSpellRow(SheetSpellRow Spell, Guid ItemId, string ItemName);

public record CharacterSheetData(
    Guid Id,
    string Name,
    CharRaceRef Race,
    CharRaceRef? SubRace,
    CharBackgroundRef Background,
    string Alignment,
    string Size,
    int Age,
    string AvatarUrl,
    int TotalLevel,
    int ProficiencyBonus,
    SheetClassRow[] Classes,
    SheetHitDiceRow[] HitDice,
    SheetAbilityRow[] Abilities,
    List<string> Languages,
    List<string> ToolProficiencies,
    List<string> WeaponProficiencies,
    List<string> ArmorProficiencies,
    Dictionary<string, int> Senses,
    int MaxHitPoints,
    int CurrentHitPoints,
    int ArmorClass,
    int Speed,
    int Initiative,
    int PassivePerception,
    SheetFeatureRow[] Features,
    SheetSpellcastingRow[] Spellcasting,
    SheetMoneyRow Money,
    SheetItemRow[] Items,
    SheetItemSpellRow[] ItemSpells);

// ---- Races ----
public record RaceListRow(Guid Id, string Name, string Source, string Size, int BaseSpeed, int SubRaceCount);
public record SubRaceDetail(
    Guid Id,
    string Name,
    string Description,
    string Source,
    Dictionary<string, int> AbilityScoreIncreases,
    int? SpeedOverride,
    List<string> BonusLanguages,
    List<string> BonusWeaponProficiencies,
    List<string> BonusToolProficiencies,
    Dictionary<string, int> BonusSenses,
    List<CatalogFeatureRef> Features);
public record RaceDetail(
    Guid Id,
    string Name,
    string Description,
    string Source,
    string Size,
    int BaseSpeed,
    List<string> Languages,
    Dictionary<string, int> AbilityScoreIncreases,
    Dictionary<string, int> Senses,
    List<CatalogFeatureRef> RacialFeatures,
    List<SubRaceDetail> SubRaces);

// ---- Classes ----
public record ClassListRow(Guid Id, string Name, string Source, string HitDie, string PrimaryStat, bool IsSpellcaster);
public record StartingEquipmentDto(CatalogItemDto Item, int Quantity);
public record EquipmentOptionDto(string Label, List<StartingEquipmentDto> Items);
public record EquipmentChoiceDto(string Name, List<EquipmentOptionDto> Options);
public record LevelProgressionDto(int Level, bool GrantsASI, List<CatalogFeatureRef> Features);
public record SubclassDto(
    Guid Id,
    string Name,
    string Description,
    string Source,
    bool IsSpellcaster,
    string? SpellcastingType,
    string? SpellcastingAbility);
public record ClassDetail(
    Guid Id,
    string Name,
    string Description,
    string Source,
    string IconUrl,
    string HitDie,
    string PrimaryStat,
    List<string> SavingThrowProficiencies,
    List<string> StartingArmorProficiencies,
    List<string> StartingWeaponProficiencies,
    List<string> StartingToolProficiencies,
    int SkillChoiceCount,
    List<string> AvailableSkills,
    bool IsSpellcaster,
    string? SpellcastingType,
    string? SpellcastingAbility,
    bool IsPreparedCaster,
    int SubclassLevel,
    List<StartingEquipmentDto> StartingEquipment,
    List<EquipmentChoiceDto> EquipmentChoices,
    Dictionary<string, int>? MulticlassPrerequisites,
    Dictionary<string, int>? MulticlassPrerequisiteAlternatives,
    int? MulticlassSkillChoiceCount,
    List<LevelProgressionDto> LevelProgressions,
    List<SubclassDto> Subclasses);

// ---- Backgrounds ----
public record BackgroundListRow(Guid Id, string Name, string Source);
public record CurrencyDto(int Copper, int Silver, int Electrum, int Gold, int Platinum);
public record BackgroundDetail(
    Guid Id,
    string Name,
    string Description,
    string Source,
    List<string> SkillProficiencies,
    List<string> ToolProficiencies,
    int AvailableLanguages,
    List<string> GrantedLanguages,
    CurrencyDto StartingMoney,
    CatalogFeatureRef? BackgroundFeature,
    List<CatalogItemDto> StartingEquipment);

// ---- Features ----
public record FeatureListRow(Guid Id, string Name, string Source, string Type, bool IsSelectableAsFeat);
public record FeatureDetail(
    Guid Id,
    string Name,
    string Description,
    string Source,
    string SourceType,
    string Type,
    bool GrantsHalfASI,
    List<string> AllowedAbilitiesForHalfASI,
    Dictionary<string, int>? AbilityIncreases,
    bool IsSelectableAsFeat);

// ---- Items ----
public record ItemListRow(
    Guid Id,
    string Name,
    string Rarity,
    double Weight,
    int ValueInCopper,
    string Visibility,
    OwnerRef? Owner,
    string? ImagePath);
public record ItemSpellRef(Guid Id, string Name, int Level, string School, string? ImagePath);
public record ItemDetail(
    Guid Id,
    string Name,
    string Description,
    string Source,
    double Weight,
    int ValueInCopper,
    string Rarity,
    OwnerRef? Owner,
    string Visibility,
    string? ImagePath,
    List<ItemSpellRef> GrantedSpells,
    Dictionary<string, int> AbilityScoreBonuses,
    int ArmorClassBonus);

// ---- Spells ----
public record SpellListRow(
    Guid Id,
    string Name,
    int Level,
    string School,
    string Visibility,
    OwnerRef? Owner,
    string? ImagePath);
public record SpellDetail(
    Guid Id,
    string Name,
    string Source,
    int Level,
    string School,
    string CastingTime,
    string Range,
    string Duration,
    string Description,
    OwnerRef? Owner,
    string Visibility,
    string? ImagePath);

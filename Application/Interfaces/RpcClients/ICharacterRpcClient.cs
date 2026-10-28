using Application.Queries.User.Character.GetLevelUpPreview;
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
using Application.Commands.User.Character.ReleaseCharacterSession;
using Application.Commands.User.Character.AddCharacterMoney;
using Application.Commands.User.Character.SpendCharacterMoney;
using Application.Commands.User.Character.RevokeCharacterShare;
using Application.Commands.User.Character.SetCharacterAbilityScores;
using Application.Commands.User.Character.ShareCharacter;
using Application.Commands.User.Character.UnequipItem;
using Application.Commands.User.Character.UnlearnSpell;
using Application.Commands.User.Character.UnprepareSpell;
using Application.Commands.User.Character.UpdateCharacter;
using Application.Core.Responses;

using Application.Queries.User.Character.GetCreationOptions;
using Application.Queries.User.Character.GetLevelUpOptions;

namespace Application.Interfaces.RpcClients;

// Talks to the (.NET / JSON-RPC) character service. Methods are addressed by name on
// the service's root route, mirroring how IUserRpcClient talks to the user service.
public interface ICharacterRpcClient
{
    // Characters
    Task<RpcResult<CreateCharacterData>> CreateCharacter(CreateCharacterCommand request, string token);
    Task<RpcResult<bool>> DeleteCharacter(DeleteCharacterCommand request, string token);
    Task<RpcResult<bool>> UpdateCharacter(UpdateCharacterCommand request, string token);
    Task<RpcResult<CharacterSheetData>> GetCharacterById(Guid id, string token);
    Task<RpcResult<PaginationResponse<CharacterListRow>>> ListCharacters(int page, int pageSize, string token);
    Task<RpcResult<List<SharedCharacterRow>>> GetSharedCharactersList(string token);
    Task<RpcResult<List<CharacterShareRow>>> GetCharacterShares(Guid characterId, string token);
    Task<RpcResult<List<CreationChoiceRow>>> GetCreationOptions(GetCreationOptionsQuery request, string token);
    Task<RpcResult<LevelUpPreviewData>> GetLevelUpPreview(GetLevelUpPreviewQuery request, string token);
    Task<RpcResult<List<CreationChoiceRow>>> GetLevelUpOptions(GetLevelUpOptionsQuery request, string token);

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
    Task<RpcResult<bool>> ReleaseCharacterSession(ReleaseCharacterSessionCommand request, string token);
    Task<RpcResult<bool>> AddCharacterMoney(AddCharacterMoneyCommand request, string token);
    Task<RpcResult<bool>> SpendCharacterMoney(SpendCharacterMoneyCommand request, string token);
    Task<RpcResult<bool>> EquipItem(EquipItemCommand request, string token);
    Task<RpcResult<bool>> UnequipItem(UnequipItemCommand request, string token);
    Task<RpcResult<bool>> AttuneItem(AttuneItemCommand request, string token);

    // Spells
    Task<RpcResult<bool>> LearnSpell(LearnSpellCommand request, string token);
    Task<RpcResult<bool>> UnlearnSpell(UnlearnSpellCommand request, string token);
    Task<RpcResult<bool>> PrepareSpell(PrepareSpellCommand request, string token);
    Task<RpcResult<bool>> UnprepareSpell(UnprepareSpellCommand request, string token);
    Task<RpcResult<List<LearnableSpellClassRow>>> GetLearnableSpells(Guid characterId, string token);

    // Sharing
    Task<RpcResult<bool>> ShareCharacter(ShareCharacterCommand request, string token);
    Task<RpcResult<bool>> RevokeCharacterShare(RevokeCharacterShareCommand request, string token);

    // Spell and item details (how a character has a spell); the rest of the catalog is the
    // workshop service's (IWorkshopRpcClient).
    Task<RpcResult<CatalogSpellInfo>> GetSpellInfo(Guid spellId, Guid? characterId, string token);
    Task<RpcResult<CatalogItemInfo>> GetItemInfo(Guid itemId, string token);
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

public record CharacterListRow(Guid Id, string Name, CharRaceRef Race, CharBackgroundRef Background, int TotalLevel, string AvatarUrl = "");

public record SharedCharacterRow(
    Guid CharacterId,
    string CharacterName,
    int TotalLevel,
    string Access,
    Guid OwnerId,
    string OwnerUserName,
    string OwnerProfilePicturePath);

public record CharacterShareRow(Guid UserId, string UserName, string ProfilePicturePath, string Access);

// ---- Character sheet ----
public record SheetSubClassRef(Guid Id, string Name);
public record SheetClassRow(Guid ClassId, string Name, string IconUrl, int Level, SheetSubClassRef? SubClass);
public record SheetHitDiceRow(string DiceType, int Total, int Used);
public record SheetSkillRow(string Skill, string Proficiency, int Modifier);
public record SheetAbilityRow(
    string Ability,
    int Value,
    int BaseValue,
    int Modifier,
    bool SavingThrowProficient,
    int SavingThrowModifier,
    SheetSkillRow[] Skills);
public record SheetFeatureRow(Guid Id, string Name, string Type, string Source = "", string Description = "");

// A class feature's uses or numbers (Rage 3 / 3 each long rest; the Martial Arts die).
public record SheetResourceRow(string Type, string Name, int Current, int Max, string Recharge, string? Die);
public record SheetSpellRow(Guid Id, string Name, int Level, string School, string? ImagePath);
public record SheetSpellcastingRow(
    Guid ClassId,
    string ClassName,
    string Type,
    bool IsPreparedCaster,
    string Kind,
    string Ability,
    int SaveDC,
    int AttackBonus,
    int KnownCantrips,
    int MaxPreparedSpells,
    int MaxKnownSpells,
    Dictionary<int, int> TotalSlots,
    SheetSpellRow[] KnownSpells,
    SheetSpellRow[] PreparedSpells,
    SheetSpellRow[] AlwaysPreparedSpells);
public record SheetSpellGrantRow(
    SheetSpellRow Spell,
    string Source,
    int MinCharacterLevel,
    bool Available,
    string Ability,
    string Uses,
    int SaveDC,
    int AttackBonus);
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
public record SheetPendingAsiRow(Guid ClassId, string ClassName, int Level);

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
    string ArmorClassSource,
    int Speed,
    int Initiative,
    int PassivePerception,
    SheetFeatureRow[] Features,
    SheetSpellcastingRow[] Spellcasting,
    SheetMoneyRow Money,
    SheetItemRow[] Items,
    SheetItemSpellRow[] ItemSpells,
    SheetPendingAsiRow[] PendingAbilityScoreImprovements,
    SheetSpellGrantRow[] SpellGrants,
    List<string> WeaponMasteries,
    int AttacksPerAction,
    int? PactWeaponAttacks,
    Guid? ActiveSessionId,
    string Access,
    SheetResourceRow[]? Resources = null);

// ---- Creation options (level 1 choices, SRD 5.2) ----
public record CreationChoiceOption(string Value, string Label, string? Description, string? Group, Guid? SpellId = null, Guid? ItemId = null);
public record CreationChoiceRow(
    string Key,
    string Step,
    string Label,
    int Count,
    CreationChoiceOption[] Options,
    string Kind,
    string? Hint,
    string[]? Defaults,
    bool Optional);

// ---- Learnable spells (per spellcasting class; Max* of 0 = no limit) ----
public record LearnableSpellRow(Guid Id, string Name, int Level, string School, string? ImagePath);
public record LearnableSpellClassRow(
    Guid ClassId,
    string ClassName,
    bool IsPreparedCaster,
    string Kind,
    int KnownCantrips,
    int MaxCantrips,
    int KnownSpells,
    int MaxKnownSpells,
    int HighestSpellLevel,
    LearnableSpellRow[] Spells,
    LearnableSpellRow[] PreparableSpells);

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

// What a level would give: each number before and after; features gained (with what they
// do); spellcasting and class resources that change. Error: it couldn't be tried.
public record LevelChange(int Before, int After);
public record LevelFeatureGain(string Name, string Description);
public record LevelCastingChange(string ClassName, LevelChange Cantrips, LevelChange Prepared, Dictionary<int, LevelChange> Slots);
public record LevelResourceChange(string Name, LevelChange Max, string? Die);
public record LevelUpPreviewData(
    string ClassName, LevelChange ClassLevel, LevelChange HitPoints, LevelChange ProficiencyBonus, LevelChange AttacksPerAction,
    LevelChange WeaponMasteries, List<LevelFeatureGain> Features, List<LevelCastingChange> Spellcasting, List<LevelResourceChange> Resources, string? Error);

// A spell's and an item's details for a window (the sheet, choosing spells, creation).
public record CatalogSpellInfo(
    Guid Id, string Name, int Level, string School, string CastingTime, string Range, string Components, string Duration,
    bool Concentration, bool Ritual, string Description, string AtHigherLevels, string Source, List<string> Classes, List<string> From);
public record CatalogItemInfo(
    Guid Id, string Name, string Kind, string? Category, string Rarity, double Weight, string Value, string Description, string Source,
    string? Damage, string? Range, List<string> Properties, string? Mastery, string? ArmorClass, int? StrengthNeeded, bool StealthDisadvantage,
    List<string> Magic);

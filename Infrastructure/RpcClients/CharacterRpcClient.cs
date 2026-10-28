using Application.Queries.User.Character.GetLevelUpPreview;
using Application.Queries.User.Character.GetCreationOptions;
using Application.Queries.User.Character.GetLevelUpOptions;
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
using Application.Interfaces.RpcClients;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.RpcClients;

// The character service is a .NET JSON-RPC service: all of its controllers share the
// root route and methods are addressed by name. Parameters are wrapped under "request"
// (DotnetRpcClient), matching how the service's controllers bind their command argument.
public class CharacterRpcClient : DotnetRpcClient, ICharacterRpcClient
{
    public CharacterRpcClient(IConfiguration configuration)
        : base(configuration["RpcServices:CharacterService"] ?? throw new Exception("CharacterService URI not set")) { }

    // --- Commands (return Unit on the service; we surface a simple success flag) ---
    public Task<RpcResult<CreateCharacterData>> CreateCharacter(CreateCharacterCommand request, string token)
        => SendData<CreateCharacterData>("CreateCharacter", request, token);

    public Task<RpcResult<bool>> DeleteCharacter(DeleteCharacterCommand request, string token)
        => SendCommand("DeleteCharacter", request, token);

    public Task<RpcResult<bool>> UpdateCharacter(UpdateCharacterCommand request, string token)
        => SendCommand("UpdateCharacter", request, token);

    public Task<RpcResult<bool>> AddClassToCharacter(AddClassToCharacterCommand request, string token)
        => SendCommand("AddClassToCharacter", request, token);

    public Task<RpcResult<bool>> ChooseSubclass(ChooseSubclassCommand request, string token)
        => SendCommand("ChooseSubclass", request, token);

    public Task<RpcResult<bool>> LevelUpCharacter(LevelUpCharacterCommand request, string token)
        => SendCommand("LevelUpCharacter", request, token);

    public Task<RpcResult<bool>> ApplyAbilityScoreImprovement(ApplyAbilityScoreImprovementCommand request, string token)
        => SendCommand("ApplyAbilityScoreImprovement", request, token);

    public Task<RpcResult<bool>> AddFeatureToCharacter(AddFeatureToCharacterCommand request, string token)
        => SendCommand("AddFeatureToCharacter", request, token);

    public Task<RpcResult<bool>> ChangeCharacterSubRace(ChangeCharacterSubRaceCommand request, string token)
        => SendCommand("ChangeCharacterSubRace", request, token);

    public Task<RpcResult<bool>> SetCharacterAbilityScores(SetCharacterAbilityScoresCommand request, string token)
        => SendCommand("SetCharacterAbilityScores", request, token);

    public Task<RpcResult<bool>> AddItemToCharacter(AddItemToCharacterCommand request, string token)
        => SendCommand("AddItemToCharacter", request, token);

    public Task<RpcResult<bool>> RemoveItemFromCharacter(RemoveItemFromCharacterCommand request, string token)
        => SendCommand("RemoveItemFromCharacter", request, token);

    public Task<RpcResult<bool>> ReleaseCharacterSession(ReleaseCharacterSessionCommand request, string token)
        => SendCommand("ReleaseCharacterSession", request, token);

    public Task<RpcResult<bool>> AddCharacterMoney(AddCharacterMoneyCommand request, string token)
        => SendCommand("AddCharacterMoney", request, token);

    public Task<RpcResult<bool>> SpendCharacterMoney(SpendCharacterMoneyCommand request, string token)
        => SendCommand("SpendCharacterMoney", request, token);

    public Task<RpcResult<bool>> EquipItem(EquipItemCommand request, string token)
        => SendCommand("EquipItem", request, token);

    public Task<RpcResult<bool>> UnequipItem(UnequipItemCommand request, string token)
        => SendCommand("UnequipItem", request, token);

    public Task<RpcResult<bool>> AttuneItem(AttuneItemCommand request, string token)
        => SendCommand("AttuneItem", request, token);

    public Task<RpcResult<bool>> LearnSpell(LearnSpellCommand request, string token)
        => SendCommand("LearnSpell", request, token);

    public Task<RpcResult<bool>> UnlearnSpell(UnlearnSpellCommand request, string token)
        => SendCommand("UnlearnSpell", request, token);

    public Task<RpcResult<bool>> PrepareSpell(PrepareSpellCommand request, string token)
        => SendCommand("PrepareSpell", request, token);

    public Task<RpcResult<bool>> UnprepareSpell(UnprepareSpellCommand request, string token)
        => SendCommand("UnprepareSpell", request, token);

    public Task<RpcResult<List<LearnableSpellClassRow>>> GetLearnableSpells(Guid characterId, string token)
        => SendData<List<LearnableSpellClassRow>>("GetLearnableSpells", new { CharacterId = characterId }, token);

    public Task<RpcResult<bool>> ShareCharacter(ShareCharacterCommand request, string token)
        => SendCommand("ShareCharacter", request, token);

    public Task<RpcResult<bool>> RevokeCharacterShare(RevokeCharacterShareCommand request, string token)
        => SendCommand("RevokeCharacterShare", request, token);

    // --- Character reads ---
    public Task<RpcResult<CharacterSheetData>> GetCharacterById(Guid id, string token)
        => SendData<CharacterSheetData>("GetCharacterById", new { Id = id }, token);

    public Task<RpcResult<PaginationResponse<CharacterListRow>>> ListCharacters(int page, int pageSize, string token)
        => SendData<PaginationResponse<CharacterListRow>>("ListCharacters", Paged(page, pageSize), token);

    public Task<RpcResult<List<SharedCharacterRow>>> GetSharedCharactersList(string token)
        => SendData<List<SharedCharacterRow>>("GetSharedCharactersList", new { }, token);

    public Task<RpcResult<List<CreationChoiceRow>>> GetCreationOptions(GetCreationOptionsQuery request, string token)
        => SendData<List<CreationChoiceRow>>("GetCreationOptions", request, token);

    public Task<RpcResult<LevelUpPreviewData>> GetLevelUpPreview(GetLevelUpPreviewQuery request, string token)
        => SendData<LevelUpPreviewData>("GetLevelUpPreview", request, token);

    public Task<RpcResult<List<CreationChoiceRow>>> GetLevelUpOptions(GetLevelUpOptionsQuery request, string token)
        => SendData<List<CreationChoiceRow>>("GetLevelUpOptions", request, token);

    public Task<RpcResult<List<CharacterShareRow>>> GetCharacterShares(Guid characterId, string token)
        => SendData<List<CharacterShareRow>>("GetCharacterShares", new { CharacterId = characterId }, token);

    // --- Spell and item details (the rest of the catalog: WorkshopRpcClient) ---
    public Task<RpcResult<CatalogSpellInfo>> GetSpellInfo(Guid spellId, Guid? characterId, string token)
        => SendData<CatalogSpellInfo>("GetSpellInfo", new { SpellId = spellId, CharacterId = characterId }, token);

    public Task<RpcResult<CatalogItemInfo>> GetItemInfo(Guid itemId, string token)
        => SendData<CatalogItemInfo>("GetItemInfo", new { ItemId = itemId }, token);

    private static object Paged(int page, int pageSize)
        => new { Pagination = new { Page = page, PageSize = pageSize } };
}

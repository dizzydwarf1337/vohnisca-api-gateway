using System.Reflection;
using System.Text.Json.Serialization;
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

    public Task<RpcResult<bool>> RenameCharacter(RenameCharacterCommand request, string token)
        => SendCommand("RenameCharacter", request, token);

    public Task<RpcResult<bool>> DeleteCharacter(DeleteCharacterCommand request, string token)
        => SendCommand("DeleteCharacter", request, token);

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

    private static object Paged(int page, int pageSize)
        => new { Pagination = new { Page = page, PageSize = pageSize } };

    // Sends a command whose service-side result is Unit; only success/failure matters.
    private async Task<RpcResult<bool>> SendCommand(string method, object payload, string token)
    {
        var result = await SendRpcRequest<DefaultRpcResponse>(method, ToDict(payload), token: token);
        return result.IsSuccess
            ? RpcResult<bool>.Success(true)
            : RpcResult<bool>.Failure(result.Error, result.StatusCode);
    }

    // Sends a request and unwraps the service's RpcResponse<T> envelope.
    private async Task<RpcResult<T>> SendData<T>(string method, object payload, string token)
    {
        var result = await SendRpcRequest<RpcDataResponse<T>>(method, ToDict(payload), token: token);
        if (!result.IsSuccess || result.Data is null)
            return RpcResult<T>.Failure(result.Error, result.StatusCode);
        return RpcResult<T>.Success(result.Data.Data);
    }

    // Turns a request/anonymous payload into the parameter map. Native CLR values are
    // kept (the JSON-RPC client serializes them), and [JsonIgnore] members (Token/UserId)
    // are skipped so only the data fields cross the wire.
    private static Dictionary<string, object> ToDict(object payload)
    {
        var dict = new Dictionary<string, object>();
        foreach (var prop in payload.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
        {
            if (prop.GetCustomAttribute<JsonIgnoreAttribute>() is not null) continue;
            var value = prop.GetValue(payload);
            if (value is null) continue;
            dict[char.ToLowerInvariant(prop.Name[0]) + prop.Name[1..]] = value;
        }
        return dict;
    }
}

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
using Application.Queries.User.Character.GetCharacterById;
using Application.Queries.User.Character.GetSharedCharactersList;
using Application.Queries.User.Character.ListCharacters;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using vohnisca_api_gateway.Core.Requests;

namespace vohnisca_api_gateway.Controllers.User.CharacterService;

[Route("characters")]
public class CharacterController : BaseController
{
    private static readonly JsonSerializerOptions PayloadJson = new()
    {
        PropertyNameCaseInsensitive = true,
    };

    [HttpGet("")]
    public Task<IActionResult> ListCharacters([FromQuery] int page = 1, [FromQuery] int pageSize = 50)
        => HandleResponse(new ListCharactersQuery { Page = page, PageSize = pageSize });

    [HttpGet("shared")]
    public Task<IActionResult> GetSharedCharacters()
        => HandleResponse(new GetSharedCharactersListQuery());

    [HttpGet("{id:guid}")]
    public Task<IActionResult> GetCharacter(Guid id)
        => id == Guid.Empty
            ? Task.FromResult<IActionResult>(BadRequest())
            : HandleResponse(new GetCharacterByIdQuery { Id = id });

    // Multipart: "payload" carries the creation JSON, "file" an optional portrait
    // (same shape as user profile updates). The image travels to the character
    // service as bytes and lands in blob storage as the character's avatar.
    [HttpPost("")]
    public async Task<IActionResult> CreateCharacter([FromForm] string payload, [FromForm] IFormFile? file)
    {
        CreateCharacterCommand? command;
        try
        {
            command = JsonSerializer.Deserialize<CreateCharacterCommand>(payload, PayloadJson);
        }
        catch (JsonException)
        {
            return BadRequest();
        }

        if (command is null)
            return BadRequest();

        var (bytes, contentType) = await GetFileContent.GetAsync(
            file, [FileType.ImageJpeg, FileType.ImagePng, FileType.ImageWebp, FileType.ImageGif]);

        command.Image = bytes;
        command.ImageContentType = contentType;

        return await HandleResponse(command);
    }

    [HttpPut("{id:guid}/name")]
    public Task<IActionResult> RenameCharacter(Guid id, RenameCharacterCommand command)
    {
        command.CharacterId = id;
        return HandleResponse(command);
    }

    [HttpDelete("{id:guid}")]
    public Task<IActionResult> DeleteCharacter(Guid id)
        => HandleResponse(new DeleteCharacterCommand { CharacterId = id });

    [HttpPut("{id:guid}/subrace")]
    public Task<IActionResult> ChangeSubRace(Guid id, ChangeCharacterSubRaceCommand command)
    {
        command.CharacterId = id;
        return HandleResponse(command);
    }

    [HttpPut("{id:guid}/ability-scores")]
    public Task<IActionResult> SetAbilityScores(Guid id, SetCharacterAbilityScoresCommand command)
    {
        command.CharacterId = id;
        return HandleResponse(command);
    }

    // Progression
    [HttpPost("{id:guid}/classes")]
    public Task<IActionResult> AddClass(Guid id, AddClassToCharacterCommand command)
    {
        command.CharacterId = id;
        return HandleResponse(command);
    }

    [HttpPost("{id:guid}/classes/subclass")]
    public Task<IActionResult> ChooseSubclass(Guid id, ChooseSubclassCommand command)
    {
        command.CharacterId = id;
        return HandleResponse(command);
    }

    [HttpPost("{id:guid}/level-up")]
    public Task<IActionResult> LevelUp(Guid id, LevelUpCharacterCommand command)
    {
        command.CharacterId = id;
        return HandleResponse(command);
    }

    [HttpPost("{id:guid}/ability-score-improvement")]
    public Task<IActionResult> ApplyAsi(Guid id, ApplyAbilityScoreImprovementCommand command)
    {
        command.CharacterId = id;
        return HandleResponse(command);
    }

    [HttpPost("{id:guid}/features")]
    public Task<IActionResult> AddFeature(Guid id, AddFeatureToCharacterCommand command)
    {
        command.CharacterId = id;
        return HandleResponse(command);
    }

    // Inventory
    [HttpPost("{id:guid}/items")]
    public Task<IActionResult> AddItem(Guid id, AddItemToCharacterCommand command)
    {
        command.CharacterId = id;
        return HandleResponse(command);
    }

    [HttpPost("{id:guid}/items/remove")]
    public Task<IActionResult> RemoveItem(Guid id, RemoveItemFromCharacterCommand command)
    {
        command.CharacterId = id;
        return HandleResponse(command);
    }

    [HttpPost("{id:guid}/items/equip")]
    public Task<IActionResult> EquipItem(Guid id, EquipItemCommand command)
    {
        command.CharacterId = id;
        return HandleResponse(command);
    }

    [HttpPost("{id:guid}/items/unequip")]
    public Task<IActionResult> UnequipItem(Guid id, UnequipItemCommand command)
    {
        command.CharacterId = id;
        return HandleResponse(command);
    }

    [HttpPost("{id:guid}/items/attune")]
    public Task<IActionResult> AttuneItem(Guid id, AttuneItemCommand command)
    {
        command.CharacterId = id;
        return HandleResponse(command);
    }

    // Spells
    [HttpPost("{id:guid}/spells/learn")]
    public Task<IActionResult> LearnSpell(Guid id, LearnSpellCommand command)
    {
        command.CharacterId = id;
        return HandleResponse(command);
    }

    [HttpPost("{id:guid}/spells/unlearn")]
    public Task<IActionResult> UnlearnSpell(Guid id, UnlearnSpellCommand command)
    {
        command.CharacterId = id;
        return HandleResponse(command);
    }

    [HttpPost("{id:guid}/spells/prepare")]
    public Task<IActionResult> PrepareSpell(Guid id, PrepareSpellCommand command)
    {
        command.CharacterId = id;
        return HandleResponse(command);
    }

    [HttpPost("{id:guid}/spells/unprepare")]
    public Task<IActionResult> UnprepareSpell(Guid id, UnprepareSpellCommand command)
    {
        command.CharacterId = id;
        return HandleResponse(command);
    }

    // Sharing
    [HttpPost("{id:guid}/share")]
    public Task<IActionResult> ShareCharacter(Guid id, ShareCharacterCommand command)
    {
        command.CharacterId = id;
        return HandleResponse(command);
    }

    [HttpPost("{id:guid}/share/revoke")]
    public Task<IActionResult> RevokeShare(Guid id, RevokeCharacterShareCommand command)
    {
        command.CharacterId = id;
        return HandleResponse(command);
    }
}

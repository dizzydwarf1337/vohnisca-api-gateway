using Application.Commands.User.Session.SetBreakableWalls;
using Application.Commands.User.Session.SetWallPiece;
using Application.Commands.User.Session.SetObjectToughness;
using Application.Commands.User.Session.SetTimeScale;
using Application.Commands.User.Session.PassTime;
using Application.Commands.User.Session.TimeCondition;
using Application.Commands.User.Session.CancelTimer;
using Application.Commands.User.Session.SetSceneVision;
using Application.Commands.User.Session.SetVisionGroups;
using Application.Commands.User.Session.SetTokenLight;
using Application.Commands.User.Session.PlaceSceneDoor;
using Application.Commands.User.Session.SetSceneLock;
using Application.Commands.User.Session.SetContainerContents;
using Application.Commands.User.Session.UseDoor;
using Application.Commands.User.Session.OpenContainer;
using Application.Commands.User.Session.TakeFromContainer;
using Application.Commands.User.Session.PutIntoContainer;
using Application.Commands.User.Session.UnlockLock;
using Application.Commands.User.Session.GatherSpill;
using Application.Commands.User.Session.IgniteSceneTerrain;
using Application.Commands.User.Session.SetSceneWalls;
using Application.Queries.User.Session.GetSpellInfo;
using Application.Queries.User.Session.GetItemInfo;
using Application.Commands.User.Session.SetLongRest;
using Application.Commands.User.Session.EquipSessionItem;
using Application.Commands.User.Session.UnequipSessionItem;
using Application.Commands.User.Session.DropItem;
using Application.Commands.User.Session.PickUpItem;
using Application.Commands.User.Session.UseItem;
using Application.Commands.User.Session.ThrowItem;
using Application.Commands.User.Session.AddSceneTerrain;
using Application.Commands.User.Session.UpdateSceneTerrain;
using Application.Commands.User.Session.RemoveSceneTerrain;
using Application.Queries.User.Session.GetEncounter;
using Application.Commands.User.Session.StartCombat;
using Application.Commands.User.Session.JoinCombat;
using Application.Commands.User.Session.RemoveCombatant;
using Application.Commands.User.Session.SetInitiative;
using Application.Commands.User.Session.EndTurn;
using Application.Commands.User.Session.EndCombat;
using Application.Commands.User.Session.SetSpent;
using Application.Commands.User.Session.Dash;
using Application.Commands.User.Session.AnswerReaction;
using Application.Commands.User.Session.Attack;
using Application.Commands.User.Session.CastSpell;
using Application.Commands.User.Session.SetShortRest;
using Application.Commands.User.Session.TakeLongRest;
using Application.Queries.User.Session.GetDiceRolls;
using Application.Commands.User.Session.RollDice;
using Application.Commands.User.Session.RollCheck;
using Application.Queries.User.Session.GetScene;
using Application.Commands.User.Session.SetScene;
using Application.Commands.User.Session.SetSceneFog;
using Application.Commands.User.Session.LoadMapLevel;
using Application.Commands.User.Session.SaveSceneToMap;
using Application.Commands.User.Session.PlaceWorkshopNpc;
using Application.Commands.User.Session.RevealSceneCells;
using Application.Commands.User.Session.AddSceneToken;
using Application.Commands.User.Session.UpdateSceneToken;
using Application.Commands.User.Session.RemoveSceneToken;
using Application.Commands.User.Session.RemoveSceneArea;
using Application.Commands.User.Session.TakeCombatAction;
using Application.Commands.User.Session.MoveSceneToken;
using Application.Commands.User.Session.ApplySessionAction;
using Application.Commands.User.Session.EndSession;
using Application.Commands.User.Session.JoinSession;
using Application.Commands.User.Session.LeaveSession;
using Application.Commands.User.Session.OpenSession;
using Application.Commands.User.Session.SetSessionReady;
using Application.Commands.User.Session.StartSession;
using Application.Queries.User.Session.GetCampaignSession;
using Application.Queries.User.Session.GetSession;
using Application.Queries.User.Session.ListMySessions;
using Application.Queries.User.Session.GetSessionDashboard;
using Microsoft.AspNetCore.Mvc;
using vohnisca_api_gateway.Core.Requests;

namespace vohnisca_api_gateway.Controllers.User.SessionService;

// Game sessions of a campaign. Live updates come over the session hub (/hubs/session,
// proxied to the session service).
[Route("")]
public class SessionController : BaseController
{
    [HttpGet]
    [Route("campaigns/{campaignId:guid}/session")]
    public Task<IActionResult> GetCampaignSession(Guid campaignId)
        => HandleResponse(new GetCampaignSessionQuery { CampaignId = campaignId });

    [HttpPost]
    [Route("campaigns/{campaignId:guid}/session")]
    public Task<IActionResult> OpenSession(Guid campaignId)
        => HandleResponse(new OpenSessionCommand { CampaignId = campaignId });

    [HttpGet]
    [Route("sessions/my")]
    public Task<IActionResult> ListMySessions()
        => HandleResponse(new ListMySessionsQuery());

    [HttpGet]
    [Route("sessions/dashboard")]
    public Task<IActionResult> GetSessionDashboard()
        => HandleResponse(new GetSessionDashboardQuery());

    [HttpGet]
    [Route("sessions/{id:guid}")]
    public Task<IActionResult> GetSession(Guid id)
        => HandleResponse(new GetSessionQuery { SessionId = id });

    [HttpPost]
    [Route("sessions/{id:guid}/join")]
    public Task<IActionResult> JoinSession(Guid id, JoinSessionCommand command)
    {
        command.SessionId = id;
        return HandleResponse(command);
    }

    [HttpPost]
    [Route("sessions/{id:guid}/leave")]
    public Task<IActionResult> LeaveSession(Guid id)
        => HandleResponse(new LeaveSessionCommand { SessionId = id });

    [HttpPost]
    [Route("sessions/{id:guid}/ready")]
    public Task<IActionResult> SetSessionReady(Guid id, SetSessionReadyCommand command)
    {
        command.SessionId = id;
        return HandleResponse(command);
    }

    [HttpPost]
    [Route("sessions/{id:guid}/start")]
    public Task<IActionResult> StartSession(Guid id)
        => HandleResponse(new StartSessionCommand { SessionId = id });

    [HttpPost]
    [Route("sessions/{id:guid}/characters/{characterId:guid}/actions")]
    public Task<IActionResult> ApplySessionAction(Guid id, Guid characterId, ApplySessionActionCommand command)
    {
        command.SessionId = id;
        command.CharacterId = characterId;
        return HandleResponse(command);
    }

    [HttpPost]
    [Route("sessions/{id:guid}/end")]
    public Task<IActionResult> EndSession(Guid id, EndSessionCommand command)
    {
        command.SessionId = id;
        return HandleResponse(command);
    }

    // ---- Scene (the map) ----

    [HttpGet]
    [Route("sessions/{id:guid}/scene")]
    public Task<IActionResult> GetScene(Guid id)
        => HandleResponse(new GetSceneQuery { SessionId = id });

    // The workshop's maps and NPCs: a map level as the scene, the scene into a map level, a
    // workshop NPC on the map.
    [HttpPost]
    [Route("sessions/{id:guid}/scene/map-level")]
    public Task<IActionResult> LoadMapLevel(Guid id, LoadMapLevelCommand command)
    {
        command.SessionId = id;
        return HandleResponse(command);
    }

    [HttpPost]
    [Route("sessions/{id:guid}/scene/save-to-map")]
    public Task<IActionResult> SaveSceneToMap(Guid id, SaveSceneToMapCommand command)
    {
        command.SessionId = id;
        return HandleResponse(command);
    }

    [HttpPost]
    [Route("sessions/{id:guid}/scene/workshop-npcs")]
    public Task<IActionResult> PlaceWorkshopNpc(Guid id, PlaceWorkshopNpcCommand command)
    {
        command.SessionId = id;
        return HandleResponse(command);
    }

    [HttpPut]
    [Route("sessions/{id:guid}/scene/walls")]
    public Task<IActionResult> SetSceneWalls(Guid id, SetSceneWallsCommand command)
    {
        command.SessionId = id;
        return HandleResponse(command);
    }

    // ---- Details for the table: a spell, an item ----

    [HttpGet]
    [Route("sessions/{id:guid}/spells/{spellId:guid}")]
    public Task<IActionResult> GetSpellInfo(Guid id, Guid spellId, [FromQuery] Guid? characterId)
        => HandleResponse(new GetSpellInfoQuery { SessionId = id, SpellId = spellId, CharacterId = characterId });

    [HttpGet]
    [Route("sessions/{id:guid}/items/{itemId:guid}")]
    public Task<IActionResult> GetItemInfo(Guid id, Guid itemId)
        => HandleResponse(new GetItemInfoQuery { SessionId = id, ItemId = itemId });

    // Multipart: name, cols, rows, fog, and optionally "file" (the background image).
    [HttpPut]
    [Route("sessions/{id:guid}/scene")]
    public async Task<IActionResult> SetScene(Guid id, [FromForm] string? name, [FromForm] int cols, [FromForm] int rows,
        [FromForm] bool fog, [FromForm] IFormFile? file)
    {
        var (bytes, contentType) = await GetFileContent.GetAsync(
            file, [FileType.ImageJpeg, FileType.ImagePng, FileType.ImageWebp, FileType.ImageGif]);

        return await HandleResponse(new SetSceneCommand
        {
            SessionId = id,
            Name = name ?? string.Empty,
            Cols = cols,
            Rows = rows,
            Fog = fog,
            Image = bytes,
            ImageContentType = contentType,
        });
    }

    [HttpPut]
    [Route("sessions/{id:guid}/scene/fog")]
    public Task<IActionResult> SetSceneFog(Guid id, SetSceneFogCommand command)
    {
        command.SessionId = id;
        return HandleResponse(command);
    }

    [HttpPost]
    [Route("sessions/{id:guid}/scene/reveal")]
    public Task<IActionResult> RevealSceneCells(Guid id, RevealSceneCellsCommand command)
    {
        command.SessionId = id;
        return HandleResponse(command);
    }

    [HttpPost]
    [Route("sessions/{id:guid}/scene/tokens")]
    public Task<IActionResult> AddSceneToken(Guid id, AddSceneTokenCommand command)
    {
        command.SessionId = id;
        return HandleResponse(command);
    }

    [HttpPut]
    [Route("sessions/{id:guid}/scene/tokens/{tokenId:guid}")]
    public Task<IActionResult> UpdateSceneToken(Guid id, Guid tokenId, UpdateSceneTokenCommand command)
    {
        command.SessionId = id;
        command.TokenId = tokenId;
        return HandleResponse(command);
    }

    [HttpDelete]
    [Route("sessions/{id:guid}/scene/tokens/{tokenId:guid}")]
    public Task<IActionResult> RemoveSceneToken(Guid id, Guid tokenId)
        => HandleResponse(new RemoveSceneTokenCommand { SessionId = id, TokenId = tokenId });

    [HttpDelete]
    [Route("sessions/{id:guid}/scene/areas/{areaId:guid}")]
    public Task<IActionResult> RemoveSceneArea(Guid id, Guid areaId)
        => HandleResponse(new RemoveSceneAreaCommand { SessionId = id, AreaId = areaId });

    [HttpPost]
    [Route("sessions/{id:guid}/scene/tokens/{tokenId:guid}/move")]
    public Task<IActionResult> MoveSceneToken(Guid id, Guid tokenId, MoveSceneTokenCommand command)
    {
        command.SessionId = id;
        command.TokenId = tokenId;
        return HandleResponse(command);
    }

    // ---- Dice ----

    [HttpGet]
    [Route("sessions/{id:guid}/dice")]
    public Task<IActionResult> GetDiceRolls(Guid id)
        => HandleResponse(new GetDiceRollsQuery { SessionId = id });

    [HttpPost]
    [Route("sessions/{id:guid}/dice")]
    public Task<IActionResult> RollDice(Guid id, RollDiceCommand command)
    {
        command.SessionId = id;
        return HandleResponse(command);
    }

    [HttpPost]
    [Route("sessions/{id:guid}/characters/{characterId:guid}/cast")]
    public Task<IActionResult> CastSpell(Guid id, Guid characterId, CastSpellCommand command)
    {
        command.SessionId = id;
        command.CharacterId = characterId;
        return HandleResponse(command);
    }

    [HttpPut]
    [Route("sessions/{id:guid}/rest/short")]
    public Task<IActionResult> SetShortRest(Guid id, SetShortRestCommand command)
    {
        command.SessionId = id;
        return HandleResponse(command);
    }

    [HttpPut]
    [Route("sessions/{id:guid}/rest/long")]
    public Task<IActionResult> SetLongRest(Guid id, SetLongRestCommand command)
    {
        command.SessionId = id;
        return HandleResponse(command);
    }

    // ---- Gear: what a character wears, carries, drops, picks up, uses, throws ----

    [HttpPost]
    [Route("sessions/{id:guid}/characters/{characterId:guid}/gear/equip")]
    public Task<IActionResult> EquipSessionItem(Guid id, Guid characterId, EquipSessionItemCommand command)
    {
        command.SessionId = id;
        command.CharacterId = characterId;
        return HandleResponse(command);
    }

    [HttpPost]
    [Route("sessions/{id:guid}/characters/{characterId:guid}/gear/unequip")]
    public Task<IActionResult> UnequipSessionItem(Guid id, Guid characterId, UnequipSessionItemCommand command)
    {
        command.SessionId = id;
        command.CharacterId = characterId;
        return HandleResponse(command);
    }

    [HttpPost]
    [Route("sessions/{id:guid}/characters/{characterId:guid}/gear/drop")]
    public Task<IActionResult> DropItem(Guid id, Guid characterId, DropItemCommand command)
    {
        command.SessionId = id;
        command.CharacterId = characterId;
        return HandleResponse(command);
    }

    [HttpPost]
    [Route("sessions/{id:guid}/characters/{characterId:guid}/gear/pick-up")]
    public Task<IActionResult> PickUpItem(Guid id, Guid characterId, PickUpItemCommand command)
    {
        command.SessionId = id;
        command.CharacterId = characterId;
        return HandleResponse(command);
    }

    [HttpPost]
    [Route("sessions/{id:guid}/characters/{characterId:guid}/gear/use")]
    public Task<IActionResult> UseItem(Guid id, Guid characterId, UseItemCommand command)
    {
        command.SessionId = id;
        command.CharacterId = characterId;
        return HandleResponse(command);
    }

    [HttpPost]
    [Route("sessions/{id:guid}/characters/{characterId:guid}/gear/throw")]
    public Task<IActionResult> ThrowItem(Guid id, Guid characterId, ThrowItemCommand command)
    {
        command.SessionId = id;
        command.CharacterId = characterId;
        return HandleResponse(command);
    }

    // ---- Terrain the GM paints ----

    [HttpPost]
    [Route("sessions/{id:guid}/scene/terrain")]
    public Task<IActionResult> AddSceneTerrain(Guid id, AddSceneTerrainCommand command)
    {
        command.SessionId = id;
        return HandleResponse(command);
    }

    [HttpPut]
    [Route("sessions/{id:guid}/scene/terrain/{terrainId:guid}")]
    public Task<IActionResult> UpdateSceneTerrain(Guid id, Guid terrainId, UpdateSceneTerrainCommand command)
    {
        command.SessionId = id;
        command.TerrainId = terrainId;
        return HandleResponse(command);
    }

    [HttpPost]
    [Route("sessions/{id:guid}/scene/terrain/{terrainId:guid}/ignite")]
    public Task<IActionResult> IgniteSceneTerrain(Guid id, Guid terrainId)
        => HandleResponse(new IgniteSceneTerrainCommand { SessionId = id, TerrainId = terrainId });

    [HttpPost]
    [Route("sessions/{id:guid}/characters/{characterId:guid}/gear/gather")]
    public Task<IActionResult> GatherSpill(Guid id, Guid characterId, GatherSpillCommand command)
    {
        command.SessionId = id;
        command.CharacterId = characterId;
        return HandleResponse(command);
    }

    [HttpDelete]
    [Route("sessions/{id:guid}/scene/terrain/{terrainId:guid}")]
    public Task<IActionResult> RemoveSceneTerrain(Guid id, Guid terrainId)
        => HandleResponse(new RemoveSceneTerrainCommand { SessionId = id, TerrainId = terrainId });

    [HttpPost]
    [Route("sessions/{id:guid}/rest/long")]
    public Task<IActionResult> TakeLongRest(Guid id)
        => HandleResponse(new TakeLongRestCommand { SessionId = id });

    [HttpPost]
    [Route("sessions/{id:guid}/characters/{characterId:guid}/checks")]
    public Task<IActionResult> RollCheck(Guid id, Guid characterId, RollCheckCommand command)
    {
        command.SessionId = id;
        command.CharacterId = characterId;
        return HandleResponse(command);
    }

    // ---- Combat ----

    [HttpGet]
    [Route("sessions/{id:guid}/combat")]
    public Task<IActionResult> GetEncounter(Guid id)
        => HandleResponse(new GetEncounterQuery { SessionId = id });

    [HttpPost]
    [Route("sessions/{id:guid}/combat")]
    public Task<IActionResult> StartCombat(Guid id, StartCombatCommand command)
    {
        command.SessionId = id;
        return HandleResponse(command);
    }

    [HttpDelete]
    [Route("sessions/{id:guid}/combat")]
    public Task<IActionResult> EndCombat(Guid id)
        => HandleResponse(new EndCombatCommand { SessionId = id });

    [HttpPost]
    [Route("sessions/{id:guid}/combat/join")]
    public Task<IActionResult> JoinCombat(Guid id, JoinCombatCommand command)
    {
        command.SessionId = id;
        return HandleResponse(command);
    }

    [HttpPost]
    [Route("sessions/{id:guid}/combat/end-turn")]
    public Task<IActionResult> EndTurn(Guid id)
        => HandleResponse(new EndTurnCommand { SessionId = id });

    [HttpPost]
    [Route("sessions/{id:guid}/combat/attack")]
    public Task<IActionResult> Attack(Guid id, AttackCommand command)
    {
        command.SessionId = id;
        return HandleResponse(command);
    }

    // A reaction on offer: taken (OptionId: how) or let pass (no OptionId).
    [HttpPost]
    [Route("sessions/{id:guid}/combat/reactions/{offerId:guid}")]
    public Task<IActionResult> AnswerReaction(Guid id, Guid offerId, AnswerReactionCommand command)
    {
        command.SessionId = id;
        command.OfferId = offerId;
        return HandleResponse(command);
    }

    [HttpDelete]
    [Route("sessions/{id:guid}/combat/{tokenId:guid}")]
    public Task<IActionResult> RemoveCombatant(Guid id, Guid tokenId)
        => HandleResponse(new RemoveCombatantCommand { SessionId = id, TokenId = tokenId });

    [HttpPut]
    [Route("sessions/{id:guid}/combat/{tokenId:guid}/initiative")]
    public Task<IActionResult> SetInitiative(Guid id, Guid tokenId, SetInitiativeCommand command)
    {
        command.SessionId = id;
        command.TokenId = tokenId;
        return HandleResponse(command);
    }

    [HttpPut]
    [Route("sessions/{id:guid}/combat/{tokenId:guid}/spent")]
    public Task<IActionResult> SetSpent(Guid id, Guid tokenId, SetSpentCommand command)
    {
        command.SessionId = id;
        command.TokenId = tokenId;
        return HandleResponse(command);
    }

    [HttpPost]
    [Route("sessions/{id:guid}/combat/{tokenId:guid}/dash")]
    public Task<IActionResult> Dash(Guid id, Guid tokenId)
        => HandleResponse(new DashCommand { SessionId = id, TokenId = tokenId });

    [HttpPost]
    [Route("sessions/{id:guid}/combat/{tokenId:guid}/action")]
    public Task<IActionResult> TakeCombatAction(Guid id, Guid tokenId, TakeCombatActionCommand command)
    {
        command.SessionId = id;
        command.TokenId = tokenId;
        return HandleResponse(command);
    }

    // ---- Doors, containers, locks ----

    [HttpPut]
    [Route("sessions/{id:guid}/scene/doors")]
    public Task<IActionResult> PlaceSceneDoor(Guid id, PlaceSceneDoorCommand command)
    {
        command.SessionId = id;
        return HandleResponse(command);
    }

    [HttpPut]
    [Route("sessions/{id:guid}/scene/locks/{targetId:guid}")]
    public Task<IActionResult> SetSceneLock(Guid id, Guid targetId, SetSceneLockCommand command)
    {
        command.SessionId = id;
        command.TargetId = targetId;
        return HandleResponse(command);
    }

    [HttpPut]
    [Route("sessions/{id:guid}/scene/tokens/{tokenId:guid}/contents")]
    public Task<IActionResult> SetContainerContents(Guid id, Guid tokenId, SetContainerContentsCommand command)
    {
        command.SessionId = id;
        command.TokenId = tokenId;
        return HandleResponse(command);
    }

    [HttpPost]
    [Route("sessions/{id:guid}/scene/doors/{doorId:guid}/use")]
    public Task<IActionResult> UseDoor(Guid id, Guid doorId, UseDoorCommand command)
    {
        command.SessionId = id;
        command.DoorId = doorId;
        return HandleResponse(command);
    }

    [HttpPost]
    [Route("sessions/{id:guid}/characters/{characterId:guid}/containers/{tokenId:guid}/open")]
    public Task<IActionResult> OpenContainer(Guid id, Guid characterId, Guid tokenId)
        => HandleResponse(new OpenContainerCommand { SessionId = id, CharacterId = characterId, TokenId = tokenId });

    [HttpPost]
    [Route("sessions/{id:guid}/characters/{characterId:guid}/containers/{tokenId:guid}/take")]
    public Task<IActionResult> TakeFromContainer(Guid id, Guid characterId, Guid tokenId, TakeFromContainerCommand command)
    {
        command.SessionId = id;
        command.CharacterId = characterId;
        command.TokenId = tokenId;
        return HandleResponse(command);
    }

    [HttpPost]
    [Route("sessions/{id:guid}/characters/{characterId:guid}/containers/{tokenId:guid}/put")]
    public Task<IActionResult> PutIntoContainer(Guid id, Guid characterId, Guid tokenId, PutIntoContainerCommand command)
    {
        command.SessionId = id;
        command.CharacterId = characterId;
        command.TokenId = tokenId;
        return HandleResponse(command);
    }

    [HttpPost]
    [Route("sessions/{id:guid}/characters/{characterId:guid}/unlock/{targetId:guid}")]
    public Task<IActionResult> UnlockLock(Guid id, Guid characterId, Guid targetId, UnlockLockCommand command)
    {
        command.SessionId = id;
        command.CharacterId = characterId;
        command.TargetId = targetId;
        return HandleResponse(command);
    }

    // ---- Sight ----

    [HttpPut]
    [Route("sessions/{id:guid}/scene/vision")]
    public Task<IActionResult> SetSceneVision(Guid id, SetSceneVisionCommand command)
    {
        command.SessionId = id;
        return HandleResponse(command);
    }

    [HttpPut]
    [Route("sessions/{id:guid}/vision-groups")]
    public Task<IActionResult> SetVisionGroups(Guid id, SetVisionGroupsCommand command)
    {
        command.SessionId = id;
        return HandleResponse(command);
    }

    [HttpPut]
    [Route("sessions/{id:guid}/scene/tokens/{tokenId:guid}/light")]
    public Task<IActionResult> SetTokenLight(Guid id, Guid tokenId, SetTokenLightCommand command)
    {
        command.SessionId = id;
        command.TokenId = tokenId;
        return HandleResponse(command);
    }

    // ---- Game time ----

    [HttpPut]
    [Route("sessions/{id:guid}/clock/scale")]
    public Task<IActionResult> SetTimeScale(Guid id, SetTimeScaleCommand command)
    {
        command.SessionId = id;
        return HandleResponse(command);
    }

    [HttpPost]
    [Route("sessions/{id:guid}/clock/pass")]
    public Task<IActionResult> PassTime(Guid id, PassTimeCommand command)
    {
        command.SessionId = id;
        return HandleResponse(command);
    }

    [HttpPut]
    [Route("sessions/{id:guid}/scene/tokens/{tokenId:guid}/condition-timer")]
    public Task<IActionResult> TimeCondition(Guid id, Guid tokenId, TimeConditionCommand command)
    {
        command.SessionId = id;
        command.TokenId = tokenId;
        return HandleResponse(command);
    }

    [HttpDelete]
    [Route("sessions/{id:guid}/clock/timers/{timerId:guid}")]
    public Task<IActionResult> CancelTimer(Guid id, Guid timerId)
        => HandleResponse(new CancelTimerCommand { SessionId = id, TimerId = timerId });

    [HttpPut]
    [Route("sessions/{id:guid}/scene/objects/{targetId:guid}/toughness")]
    public Task<IActionResult> SetObjectToughness(Guid id, Guid targetId, SetObjectToughnessCommand command)
    {
        command.SessionId = id;
        command.TargetId = targetId;
        return HandleResponse(command);
    }

    [HttpPut]
    [Route("sessions/{id:guid}/scene/walls/breakable")]
    public Task<IActionResult> SetBreakableWalls(Guid id, SetBreakableWallsCommand command)
    {
        command.SessionId = id;
        return HandleResponse(command);
    }

    [HttpPut]
    [Route("sessions/{id:guid}/scene/walls/pieces/{pieceId:guid}")]
    public Task<IActionResult> SetWallPiece(Guid id, Guid pieceId, SetWallPieceCommand command)
    {
        command.SessionId = id;
        command.PieceId = pieceId;
        return HandleResponse(command);
    }
}

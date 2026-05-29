using Application.Commands.User.Campaign.Note.CreateNote;
using Application.Commands.User.Campaign.Note.DeleteNote;
using Application.Commands.User.Campaign.Note.GrantNoteAccess;
using Application.Commands.User.Campaign.Note.ReorderNotes;
using Application.Commands.User.Campaign.Note.RevokeNoteAccess;
using Application.Commands.User.Campaign.Note.SetNoteVisibility;
using Application.Commands.User.Campaign.Note.UpdateNote;
using Application.Queries.User.Campaign.Note.GetNote;
using Microsoft.AspNetCore.Mvc;

namespace vohnisca_api_gateway.Controllers.User.CampaignService;

[Route("notes")]
public class NoteController : BaseController
{
    [HttpPost("")]
    public Task<IActionResult> CreateNote(CreateNoteCommand? command)
    {
        if (command is null) return Task.FromResult<IActionResult>(BadRequest());
        return HandleResponse(command);
    }

    [HttpGet("{id:guid}")]
    public Task<IActionResult> GetNote(Guid id)
    {
        if (id == Guid.Empty) return Task.FromResult<IActionResult>(BadRequest());
        return HandleResponse(new GetNoteQuery { NoteId = id.ToString() });
    }

    [HttpPut("{id:guid}")]
    public Task<IActionResult> UpdateNote(Guid id, UpdateNoteCommand? command)
    {
        if (id == Guid.Empty) return Task.FromResult<IActionResult>(BadRequest());
        if (command is null) return Task.FromResult<IActionResult>(BadRequest());
        command.NoteId = id.ToString();
        return HandleResponse(command);
    }

    [HttpDelete("{id:guid}")]
    public Task<IActionResult> DeleteNote(Guid id)
    {
        if (id == Guid.Empty) return Task.FromResult<IActionResult>(BadRequest());
        return HandleResponse(new DeleteNoteCommand { NoteId = id.ToString() });
    }

    [HttpPut("reorder")]
    public Task<IActionResult> ReorderNotes(ReorderNotesCommand? command)
    {
        if (command is null) return Task.FromResult<IActionResult>(BadRequest());
        return HandleResponse(command);
    }

    [HttpPut("{id:guid}/visibility")]
    public Task<IActionResult> SetNoteVisibility(Guid id, SetNoteVisibilityCommand? command)
    {
        if (id == Guid.Empty) return Task.FromResult<IActionResult>(BadRequest());
        if (command is null) return Task.FromResult<IActionResult>(BadRequest());
        command.NoteId = id.ToString();
        return HandleResponse(command);
    }

    [HttpPost("{id:guid}/access")]
    public Task<IActionResult> GrantNoteAccess(Guid id, GrantNoteAccessCommand? command)
    {
        if (id == Guid.Empty) return Task.FromResult<IActionResult>(BadRequest());
        if (command is null) return Task.FromResult<IActionResult>(BadRequest());
        command.NoteId = id.ToString();
        return HandleResponse(command);
    }

    [HttpDelete("{id:guid}/access/{targetUserId}")]
    public Task<IActionResult> RevokeNoteAccess(Guid id, string targetUserId)
    {
        if (id == Guid.Empty || string.IsNullOrEmpty(targetUserId))
            return Task.FromResult<IActionResult>(BadRequest());
        return HandleResponse(new RevokeNoteAccessCommand { NoteId = id.ToString(), TargetUserId = targetUserId });
    }
}

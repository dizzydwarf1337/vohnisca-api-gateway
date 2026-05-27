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
    public Task<IActionResult> CreateNote(CreateNoteCommand command)
        => HandleResponse(command);

    [HttpGet("{id}")]
    public Task<IActionResult> GetNote(string id)
        => HandleResponse(new GetNoteQuery { NoteId = id });

    [HttpPut("{id}")]
    public Task<IActionResult> UpdateNote(string id, UpdateNoteCommand command)
    {
        command.NoteId = id;
        return HandleResponse(command);
    }

    [HttpDelete("{id}")]
    public Task<IActionResult> DeleteNote(string id)
        => HandleResponse(new DeleteNoteCommand { NoteId = id });

    [HttpPut("reorder")]
    public Task<IActionResult> ReorderNotes(ReorderNotesCommand command)
        => HandleResponse(command);

    [HttpPut("{id}/visibility")]
    public Task<IActionResult> SetNoteVisibility(string id, SetNoteVisibilityCommand command)
    {
        command.NoteId = id;
        return HandleResponse(command);
    }

    [HttpPost("{id}/access")]
    public Task<IActionResult> GrantNoteAccess(string id, GrantNoteAccessCommand command)
    {
        command.NoteId = id;
        return HandleResponse(command);
    }

    [HttpDelete("{id}/access/{targetUserId}")]
    public Task<IActionResult> RevokeNoteAccess(string id, string targetUserId)
        => HandleResponse(new RevokeNoteAccessCommand { NoteId = id, TargetUserId = targetUserId });
}
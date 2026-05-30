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
    [HttpPost]
    [Route("")]
    public async Task<IActionResult> CreateNote(CreateNoteCommand command)
        => await HandleResponse(command);

    [HttpGet]
    [Route("{id:guid}")]
    public async Task<IActionResult> GetNote(Guid id)
    {
        if (id == Guid.Empty)
            return BadRequest();

        return await HandleResponse(new GetNoteQuery { NoteId = id });
    }

    [HttpPut]
    [Route("{id:guid}")]
    public async Task<IActionResult> UpdateNote(Guid id, UpdateNoteCommand command)
    {
        if (id == Guid.Empty || command is null)
            return BadRequest();

        command.NoteId = id;

        return await HandleResponse(command);
    }

    [HttpDelete]
    [Route("{id:guid}")]
    public async Task<IActionResult> DeleteNote(Guid id)
    {
        if (id == Guid.Empty)
            return BadRequest();

        return await HandleResponse(new DeleteNoteCommand { NoteId = id });
    }

    [HttpPut]
    [Route("reorder")]
    public async Task<IActionResult> ReorderNotes(ReorderNotesCommand command)
        => await HandleResponse(command);

    [HttpPut]
    [Route("{id:guid}/visibility")]
    public async Task<IActionResult> SetNoteVisibility(Guid id, SetNoteVisibilityCommand command)
    {
        if (id == Guid.Empty || command is null) return BadRequest();

        command.NoteId = id;

        return await HandleResponse(command);
    }

    [HttpPost]
    [Route("{id:guid}/access")]
    public async Task<IActionResult> GrantNoteAccess(Guid id, GrantNoteAccessCommand command)
    {
        if (id == Guid.Empty || command is null) return BadRequest();

        command.NoteId = id;

        return await HandleResponse(command);
    }

    [HttpDelete]
    [Route("{id:guid}/access/{targetUserId:guid}")]
    public async Task<IActionResult> RevokeNoteAccess(Guid id, Guid targetUserId)
    {
        if (id == Guid.Empty || targetUserId == Guid.Empty)
            return BadRequest();

        return await HandleResponse(new RevokeNoteAccessCommand
            { NoteId = id, TargetUserId = targetUserId });
    }
}
using Application.Commands.User.Campaign.Chapter.CreateChapter;
using Application.Commands.User.Campaign.Chapter.DeleteChapter;
using Application.Commands.User.Campaign.Chapter.GrantChapterAccess;
using Application.Commands.User.Campaign.Chapter.MoveChapter;
using Application.Commands.User.Campaign.Chapter.ReorderChapters;
using Application.Commands.User.Campaign.Chapter.RevokeChapterAccess;
using Application.Commands.User.Campaign.Chapter.SetChapterVisibility;
using Application.Commands.User.Campaign.Chapter.SetCurrentChapter;
using Application.Commands.User.Campaign.Chapter.UpdateChapter;
using Application.Queries.User.Campaign.Chapter.GetChapter;
using Application.Queries.User.Campaign.Chapter.ListCampaignChapters;
using Application.Queries.User.Campaign.Note.ListChapterNotes;
using Microsoft.AspNetCore.Mvc;

namespace vohnisca_api_gateway.Controllers.User.CampaignService;

[Route("chapters")]
public class ChapterController : BaseController
{
    [HttpPost("")]
    public Task<IActionResult> CreateChapter(CreateChapterCommand? command)
    {
        if (command is null) return Task.FromResult<IActionResult>(BadRequest());
        return HandleResponse(command);
    }

    [HttpGet("{id:guid}")]
    public Task<IActionResult> GetChapter(Guid id)
    {
        if (id == Guid.Empty) return Task.FromResult<IActionResult>(BadRequest());
        return HandleResponse(new GetChapterQuery { ChapterId = id.ToString() });
    }

    [HttpPut("{id:guid}")]
    public Task<IActionResult> UpdateChapter(Guid id, UpdateChapterCommand? command)
    {
        if (id == Guid.Empty) return Task.FromResult<IActionResult>(BadRequest());
        if (command is null) return Task.FromResult<IActionResult>(BadRequest());
        command.ChapterId = id.ToString();
        return HandleResponse(command);
    }

    [HttpDelete("{id:guid}")]
    public Task<IActionResult> DeleteChapter(Guid id)
    {
        if (id == Guid.Empty) return Task.FromResult<IActionResult>(BadRequest());
        return HandleResponse(new DeleteChapterCommand { ChapterId = id.ToString() });
    }

    [HttpPut("{id:guid}/move")]
    public Task<IActionResult> MoveChapter(Guid id, MoveChapterCommand? command)
    {
        if (id == Guid.Empty) return Task.FromResult<IActionResult>(BadRequest());
        if (command is null) return Task.FromResult<IActionResult>(BadRequest());
        command.ChapterId = id.ToString();
        return HandleResponse(command);
    }

    [HttpPut("reorder")]
    public Task<IActionResult> ReorderChapters(ReorderChaptersCommand? command)
    {
        if (command is null) return Task.FromResult<IActionResult>(BadRequest());
        return HandleResponse(command);
    }

    [HttpPut("{id:guid}/visibility")]
    public Task<IActionResult> SetChapterVisibility(Guid id, SetChapterVisibilityCommand? command)
    {
        if (id == Guid.Empty) return Task.FromResult<IActionResult>(BadRequest());
        if (command is null) return Task.FromResult<IActionResult>(BadRequest());
        command.ChapterId = id.ToString();
        return HandleResponse(command);
    }

    [HttpPost("{id:guid}/access")]
    public Task<IActionResult> GrantChapterAccess(Guid id, GrantChapterAccessCommand? command)
    {
        if (id == Guid.Empty) return Task.FromResult<IActionResult>(BadRequest());
        if (command is null) return Task.FromResult<IActionResult>(BadRequest());
        command.ChapterId = id.ToString();
        return HandleResponse(command);
    }

    [HttpDelete("{id:guid}/access/{targetUserId}")]
    public Task<IActionResult> RevokeChapterAccess(Guid id, string targetUserId)
    {
        if (id == Guid.Empty || string.IsNullOrEmpty(targetUserId))
            return Task.FromResult<IActionResult>(BadRequest());
        return HandleResponse(new RevokeChapterAccessCommand { ChapterId = id.ToString(), TargetUserId = targetUserId });
    }

    [HttpPut("{id:guid}/current")]
    public Task<IActionResult> SetCurrentChapter(Guid id, SetCurrentChapterCommand? command)
    {
        if (id == Guid.Empty) return Task.FromResult<IActionResult>(BadRequest());
        if (command is null) return Task.FromResult<IActionResult>(BadRequest());
        command.ChapterId = id.ToString();
        return HandleResponse(command);
    }

    [HttpGet("{id:guid}/notes")]
    public Task<IActionResult> ListChapterNotes(Guid id)
    {
        if (id == Guid.Empty) return Task.FromResult<IActionResult>(BadRequest());
        return HandleResponse(new ListChapterNotesQuery { ChapterId = id.ToString() });
    }

    [HttpGet("/campaigns/{campaignId:guid}/chapters")]
    public Task<IActionResult> ListCampaignChapters(Guid campaignId)
    {
        if (campaignId == Guid.Empty) return Task.FromResult<IActionResult>(BadRequest());
        return HandleResponse(new ListCampaignChaptersQuery { CampaignId = campaignId.ToString() });
    }
}
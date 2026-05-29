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
    public Task<IActionResult> CreateChapter(CreateChapterCommand command)
        => HandleResponse(command);

    [HttpGet("{id}")]
    public Task<IActionResult> GetChapter(string id)
        => HandleResponse(new GetChapterQuery { ChapterId = id });

    [HttpPut("{id}")]
    public Task<IActionResult> UpdateChapter(string id, UpdateChapterCommand command)
    {
        command.ChapterId = id;
        return HandleResponse(command);
    }

    [HttpDelete("{id}")]
    public Task<IActionResult> DeleteChapter(string id)
        => HandleResponse(new DeleteChapterCommand { ChapterId = id });

    [HttpPut("{id}/move")]
    public Task<IActionResult> MoveChapter(string id, MoveChapterCommand command)
    {
        command.ChapterId = id;
        return HandleResponse(command);
    }

    [HttpPut("reorder")]
    public Task<IActionResult> ReorderChapters(ReorderChaptersCommand command)
        => HandleResponse(command);

    [HttpPut("{id}/visibility")]
    public Task<IActionResult> SetChapterVisibility(string id, SetChapterVisibilityCommand command)
    {
        command.ChapterId = id;
        return HandleResponse(command);
    }

    [HttpPost("{id}/access")]
    public Task<IActionResult> GrantChapterAccess(string id, GrantChapterAccessCommand command)
    {
        command.ChapterId = id;
        return HandleResponse(command);
    }

    [HttpDelete("{id}/access/{targetUserId}")]
    public Task<IActionResult> RevokeChapterAccess(string id, string targetUserId)
        => HandleResponse(new RevokeChapterAccessCommand { ChapterId = id, TargetUserId = targetUserId });

    [HttpPut("{id}/current")]
    public Task<IActionResult> SetCurrentChapter(string id, SetCurrentChapterCommand command)
    {
        command.ChapterId = id;
        return HandleResponse(command);
    }

    [HttpGet("{id}/notes")]
    public Task<IActionResult> ListChapterNotes(string id)
        => HandleResponse(new ListChapterNotesQuery { ChapterId = id });

    [HttpGet("/campaigns/{campaignId}/chapters")]
    public Task<IActionResult> ListCampaignChapters(string campaignId)
        => HandleResponse(new ListCampaignChaptersQuery { CampaignId = campaignId });
}
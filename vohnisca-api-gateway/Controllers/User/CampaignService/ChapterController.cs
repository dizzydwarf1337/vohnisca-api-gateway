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
    [HttpPost]
    [Route("")]
    public async Task<IActionResult> CreateChapter(CreateChapterCommand command)
        => await HandleResponse(command);


    [HttpGet]
    [Route("{id:guid}")]
    public async Task<IActionResult> GetChapter(Guid id)
    {
        if (id == Guid.Empty)
            return BadRequest();

        return await HandleResponse(new GetChapterQuery { ChapterId = id });
    }

    [HttpPut]
    [Route("{id:guid}")]
    public async Task<IActionResult> UpdateChapter(Guid id, UpdateChapterCommand command)
    {
        if (id == Guid.Empty || command is null)
            return BadRequest();

        command.ChapterId = id;

        return await HandleResponse(command);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteChapter(Guid id)
    {
        if (id == Guid.Empty)
            return BadRequest();

        return await HandleResponse(new DeleteChapterCommand { ChapterId = id });
    }

    [HttpPut]
    [Route("{id:guid}/move")]
    public async Task<IActionResult> MoveChapter(Guid id, MoveChapterCommand command)
    {
        if (id == Guid.Empty || command is null)
            return BadRequest();

        command.ChapterId = id;

        return await HandleResponse(command);
    }

    [HttpPut]
    [Route("reorder")]
    public async Task<IActionResult> ReorderChapters(ReorderChaptersCommand command)
        => await HandleResponse(command);

    [HttpPut("{id:guid}/visibility")]
    public async Task<IActionResult> SetChapterVisibility(Guid id, SetChapterVisibilityCommand command)
    {
        if (id == Guid.Empty || command is null)
            return BadRequest();

        command.ChapterId = id;

        return await HandleResponse(command);
    }

    [HttpPost]
    [Route("{id:guid}/access")]
    public async Task<IActionResult> GrantChapterAccess(Guid id, GrantChapterAccessCommand command)
    {
        if (id == Guid.Empty || command is null) return BadRequest();

        command.ChapterId = id;

        return await HandleResponse(command);
    }

    [HttpDelete]
    [Route("{id:guid}/access/{targetUserId:guid}")]
    public async Task<IActionResult> RevokeChapterAccess(Guid id, Guid targetUserId)
    {
        if (id == Guid.Empty || targetUserId == Guid.Empty)
            return BadRequest();

        return await HandleResponse(new RevokeChapterAccessCommand
            { ChapterId = id, TargetUserId = targetUserId });
    }

    [HttpPut]
    [Route("{id:guid}/current")]
    public async Task<IActionResult> SetCurrentChapter(Guid id, SetCurrentChapterCommand command)
    {
        if (id == Guid.Empty || command is null) return BadRequest();

        command.ChapterId = id;

        return await HandleResponse(command);
    }

    [HttpGet]
    [Route("{id:guid}/notes")]
    public async Task<IActionResult> ListChapterNotes(Guid id)
    {
        if (id == Guid.Empty) return BadRequest();
        return await HandleResponse(new ListChapterNotesQuery { ChapterId = id });
    }

    [HttpGet]
    [Route("/campaigns/{campaignId:guid}/chapters")]
    public async Task<IActionResult> ListCampaignChapters(Guid campaignId)
    {
        if (campaignId == Guid.Empty) return BadRequest();
        return await HandleResponse(new ListCampaignChaptersQuery { CampaignId = campaignId });
    }
}
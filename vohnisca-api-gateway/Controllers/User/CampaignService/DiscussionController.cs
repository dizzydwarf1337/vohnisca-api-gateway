using Application.Commands.User.Campaign.Discussion.CreateCampaignThread;
using Application.Commands.User.Campaign.Discussion.CreateChapterThread;
using Application.Commands.User.Campaign.Discussion.CreatePost;
using Application.Commands.User.Campaign.Discussion.DeletePost;
using Application.Commands.User.Campaign.Discussion.EditPost;
using Application.Commands.User.Campaign.Discussion.MarkThreadRead;
using Application.Commands.User.Campaign.Discussion.SetThreadHidden;
using Application.Commands.User.Campaign.Discussion.SetThreadLocked;
using Application.Commands.User.Campaign.Discussion.SetThreadPinned;
using Application.Queries.User.Campaign.Discussion.GetThread;
using Application.Queries.User.Campaign.Discussion.GetUnreadCounts;
using Application.Queries.User.Campaign.Discussion.ListCampaignThreads;
using Application.Queries.User.Campaign.Discussion.ListChapterThreads;
using Microsoft.AspNetCore.Mvc;

namespace vohnisca_api_gateway.Controllers.User.CampaignService;

// The campaign's discussion: one forum for the campaign itself and one per chapter (the same threads table,
// chapterId tells them apart). No real-time: the client polls an open thread. Who may see a thread, hide it
// or write in a locked one is the campaign service's call — the gateway only carries the routes.
public class DiscussionController : BaseController
{
    [HttpGet]
    [Route("/campaigns/{id:guid}/threads")]
    public async Task<IActionResult> ListCampaignThreads(Guid id, [FromQuery] int page = 1, [FromQuery] int pageSize = 50)
    {
        if (id == Guid.Empty)
            return BadRequest();

        return await HandleResponse(new ListCampaignThreadsQuery { CampaignId = id, Page = page, PageSize = pageSize });
    }

    [HttpPost]
    [Route("/campaigns/{id:guid}/threads")]
    public async Task<IActionResult> CreateCampaignThread(Guid id, CreateCampaignThreadCommand command)
    {
        if (id == Guid.Empty || command is null)
            return BadRequest();

        command.CampaignId = id;

        return await HandleResponse(command);
    }

    [HttpGet]
    [Route("/chapters/{id:guid}/threads")]
    public async Task<IActionResult> ListChapterThreads(Guid id, [FromQuery] int page = 1, [FromQuery] int pageSize = 50)
    {
        if (id == Guid.Empty)
            return BadRequest();

        return await HandleResponse(new ListChapterThreadsQuery { ChapterId = id, Page = page, PageSize = pageSize });
    }

    [HttpPost]
    [Route("/chapters/{id:guid}/threads")]
    public async Task<IActionResult> CreateChapterThread(Guid id, CreateChapterThreadCommand command)
    {
        if (id == Guid.Empty || command is null)
            return BadRequest();

        command.ChapterId = id;

        return await HandleResponse(command);
    }

    [HttpGet]
    [Route("/threads/{id:guid}")]
    public async Task<IActionResult> GetThread(Guid id, [FromQuery] int page = 1, [FromQuery] int pageSize = 50)
    {
        if (id == Guid.Empty)
            return BadRequest();

        return await HandleResponse(new GetThreadQuery { ThreadId = id, Page = page, PageSize = pageSize });
    }

    [HttpPost]
    [Route("/threads/{id:guid}/posts")]
    public async Task<IActionResult> CreatePost(Guid id, CreatePostCommand command)
    {
        if (id == Guid.Empty || command is null)
            return BadRequest();

        command.ThreadId = id;

        return await HandleResponse(command);
    }

    [HttpPut]
    [Route("/posts/{id:guid}")]
    public async Task<IActionResult> EditPost(Guid id, EditPostCommand command)
    {
        if (id == Guid.Empty || command is null)
            return BadRequest();

        command.PostId = id;

        return await HandleResponse(command);
    }

    [HttpDelete]
    [Route("/posts/{id:guid}")]
    public async Task<IActionResult> DeletePost(Guid id)
    {
        if (id == Guid.Empty)
            return BadRequest();

        return await HandleResponse(new DeletePostCommand { PostId = id });
    }

    [HttpPut]
    [Route("/threads/{id:guid}/pin")]
    public async Task<IActionResult> SetThreadPinned(Guid id, SetThreadPinnedCommand command)
    {
        if (id == Guid.Empty || command is null)
            return BadRequest();

        command.ThreadId = id;

        return await HandleResponse(command);
    }

    [HttpPut]
    [Route("/threads/{id:guid}/lock")]
    public async Task<IActionResult> SetThreadLocked(Guid id, SetThreadLockedCommand command)
    {
        if (id == Guid.Empty || command is null)
            return BadRequest();

        command.ThreadId = id;

        return await HandleResponse(command);
    }

    [HttpPut]
    [Route("/threads/{id:guid}/hide")]
    public async Task<IActionResult> SetThreadHidden(Guid id, SetThreadHiddenCommand command)
    {
        if (id == Guid.Empty || command is null)
            return BadRequest();

        command.ThreadId = id;

        return await HandleResponse(command);
    }

    [HttpPost]
    [Route("/threads/{id:guid}/read")]
    public async Task<IActionResult> MarkThreadRead(Guid id)
    {
        if (id == Guid.Empty)
            return BadRequest();

        return await HandleResponse(new MarkThreadReadCommand { ThreadId = id });
    }

    [HttpGet]
    [Route("/campaigns/{id:guid}/discussion/unread")]
    public async Task<IActionResult> GetUnreadCounts(Guid id)
    {
        if (id == Guid.Empty)
            return BadRequest();

        return await HandleResponse(new GetUnreadCountsQuery { CampaignId = id });
    }
}
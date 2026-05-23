using Application.Commands.User.User.FriendRequests.AcceptFriendRequest;
using Application.Commands.User.User.FriendRequests.CancelFriendRequest;
using Application.Commands.User.User.FriendRequests.DeleteFriendRequest;
using Application.Commands.User.User.FriendRequests.RejectFriendRequest;
using Application.Commands.User.User.FriendRequests.SendFriendRequest;
using Application.Queries.User.User.FriendRequests.GetFriendRequests;
using Application.Queries.User.User.FriendRequests.GetSentFriendRequests;
using Microsoft.AspNetCore.Mvc;

namespace vohnisca_api_gateway.Controllers.User.UserService;

[Route("friend-requests")]
public class FriendRequestController : BaseController
{
    [HttpPost]
    [Route("send")]
    public async Task<IActionResult> SendFriendRequest(SendFriendRequestCommand command)
        => await HandleResponse(command);

    [HttpPut]
    [Route("{id:guid}/accept")]
    public async Task<IActionResult> AcceptFriendRequest(Guid id)
    {
        if (id == Guid.Empty)
            return BadRequest();

        return await HandleResponse(new AcceptFriendRequestCommand { Id = id });
    }

    [HttpPut]
    [Route("{id:guid}/reject")]
    public async Task<IActionResult> RejectFriendRequest(Guid id)
    {
        if (id == Guid.Empty)
            return BadRequest();

        return await HandleResponse(new RejectFriendRequestCommand { Id = id });
    }

    [HttpPut]
    [Route("{id:guid}/cancel")]
    public async Task<IActionResult> CancelFriendRequest(Guid id)
    {
        if (id == Guid.Empty)
            return BadRequest();

        return await HandleResponse(new CancelFriendRequestCommand { Id = id });
    }

    [HttpDelete]
    [Route("{id:guid}/delete")]
    public async Task<IActionResult> DeleteFriendRequest(Guid id)
    {
        if (id == Guid.Empty)
            return BadRequest();

        return await HandleResponse(new DeleteFriendRequestCommand { Id = id });
    }

    [HttpPost]
    [Route("")]
    public async Task<IActionResult> GetReceivedFriendRequests(GetFriendRequestsQuery query)
        => await HandleResponse(query);

    [HttpPost]
    [Route("sent")]
    public async Task<IActionResult> GetSentFriendRequests(GetSentFriendRequestsQuery query)
        => await HandleResponse(query);
}
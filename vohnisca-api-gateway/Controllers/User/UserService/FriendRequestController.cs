using Application.Commands.User.User.FriendRequests.AcceptFriendRequest;
using Application.Commands.User.User.FriendRequests.RejectFriendRequest;
using Application.Commands.User.User.FriendRequests.SendFriendRequest;
using Application.Queries.User.User.FriendRequests.GetFriendRequests;
using Microsoft.AspNetCore.Mvc;

namespace vohnisca_api_gateway.Controllers.User.UserService;

[Route("friend-requests")]
public class FriendRequestController : BaseController
{
    [HttpPost]
    [Route("send")]
    public async Task<IActionResult> SendFriendRequest(SendFriendRequestCommand command)
        => await HandleResponse(command);
    
    [HttpPost]
    [Route("{id:guid}/accept")]
    public async Task<IActionResult> AcceptFriendRequest(Guid id)
    {
        if (id == Guid.Empty)
            return BadRequest();
        return await HandleResponse(new AcceptFriendRequestCommand { Id = id });
    }
    
    [HttpPost]
    [Route("{id:guid}/reject")]
    public async Task<IActionResult> RejectFriendRequest(Guid id)
    {
        if (id == Guid.Empty)
            return BadRequest();
        return await HandleResponse(new RejectFriendRequestCommand { Id = id });
    }

    [HttpGet]
    [Route("")]
    public async Task<IActionResult> GetReceivedFriendRequests()
        => await HandleResponse(new GetFriendRequestsQuery());
}
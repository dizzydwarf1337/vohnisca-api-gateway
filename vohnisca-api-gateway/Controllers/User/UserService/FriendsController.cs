using Application.Commands.User.User.Friends.DeleteFriend;
using Application.Queries.User.User.Friends.GetFriends;
using Microsoft.AspNetCore.Mvc;

namespace vohnisca_api_gateway.Controllers.User.UserService;

[Route("friends")]
public class FriendsController : BaseController
{
    [HttpDelete]
    [Route("{id:guid}")]
    public async Task<IActionResult> DeleteFriend(Guid id)
    {
        if (id == Guid.Empty)
            return BadRequest();

        return await HandleResponse(new DeleteFriendCommand
        {
            Id = id
        });
    }

    [HttpPost]
    [Route("")]
    public async Task<IActionResult> GetFriends(GetFriendsQuery query)
        => await HandleResponse(query);
}
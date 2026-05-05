using Application.Queries.User.User.Me.GetMe;
using Microsoft.AspNetCore.Mvc;

namespace vohnisca_api_gateway.Controllers.User.UserService;

[Route("user")]
public class UserController : BaseController
{
    [HttpGet]
    [Route("get-me")]
    public async Task<IActionResult> GetMe()
        => await HandleResponse(new GetMeQuery());
}
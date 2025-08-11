using Application.Commands.Public.Auth.Login;
using Application.Commands.Public.Auth.SignUp;
using Microsoft.AspNetCore.Mvc;

namespace vohnisca_api_gateway.Controllers.Public.Auth;

[Route("public/auth")]
public class AuthController : BaseController
{
    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login(LoginCommand command)
        => HandleResponse(await Mediator.Send(command));
    [HttpPost]
    [Route("sign-up")]
    public async Task<IActionResult> SignUp(SignUpCommand command)
        => HandleResponse(await Mediator.Send(command));
}
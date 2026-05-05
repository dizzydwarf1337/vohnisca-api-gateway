using Application.Commands.Public.Auth.ConfirmEmail;
using Application.Commands.Public.Auth.Login;
using Application.Commands.Public.Auth.SignUp;
using Application.Commands.Public.Auth.RefreshToken;
using Microsoft.AspNetCore.Mvc;

namespace vohnisca_api_gateway.Controllers.Public.Auth;

[Route("public/auth")]
public class AuthController : BaseController
{
    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login(LoginCommand command)
        => await HandleResponse(command);

    [HttpPost]
    [Route("sign-up")]
    public async Task<IActionResult> SignUp(SignUpCommand command)
        => await HandleResponse(command);

    [HttpPost]
    [Route("confirm-email")]
    public async Task<IActionResult> ConfirmEmail(ConfirmEmailCommand command)
        => await HandleResponse(command);

    [HttpPost]
    [Route("refresh")]
    public async Task<IActionResult> RefreshToken(RefreshTokenCommand command)
        => await HandleResponse(command);
}
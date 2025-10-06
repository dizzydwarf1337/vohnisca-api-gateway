using Application.Core.Mediatr.Requests.PublicRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.Public.Auth.Login;

public class LoginCommand : PublicRequest<LoginCommand.Result>
{
    public required string Email { get; set; }
    public required string Password { get; set; }

    public record Result(string Token, string TokenType, string ExpiresIn);
}
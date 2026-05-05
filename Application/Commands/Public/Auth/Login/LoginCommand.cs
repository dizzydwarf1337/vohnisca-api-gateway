using Application.Core.Mediatr.Requests.PublicRequest;

namespace Application.Commands.Public.Auth.Login;

public class LoginCommand : PublicRequest<LoginCommand.Result>
{
    public required string Email { get; set; }
    public required string Password { get; set; }

    public record Result(string Token, string RefreshToken, string TokenType, string ExpiresIn);
}
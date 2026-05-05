using Application.Core.Mediatr.Requests.PublicRequest;

namespace Application.Commands.Public.Auth.RefreshToken;

public class RefreshTokenCommand : PublicRequest<RefreshTokenCommand.Result>
{
    public string RefreshToken { get; set; }
    public record Result(string AccessToken, string TokenType, string ExpiresIn);
}

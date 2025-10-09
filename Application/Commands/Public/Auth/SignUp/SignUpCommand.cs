using Application.Core.Mediatr.Requests.PublicRequest;

namespace Application.Commands.Public.Auth.SignUp;

public class SignUpCommand : PublicRequest<SignUpCommand.Result>
{
    public required string Email { get; set; }
    public required string Password { get; set; }
    public required string PasswordConfirmation { get; set; }
    public required string Name { get; set; }

    public record Result(string? Message = null);
}
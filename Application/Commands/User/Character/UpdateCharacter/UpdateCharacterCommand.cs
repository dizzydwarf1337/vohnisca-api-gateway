using Application.Core.Mediatr.Requests.UserRequest;

namespace Application.Commands.User.Character.UpdateCharacter;

// Name plus an optional new portrait, sent to the character service in one request.
public class UpdateCharacterCommand : UserRequest<bool>
{
    public Guid CharacterId { get; set; }
    public string Name { get; set; } = string.Empty;
    public byte[]? Image { get; set; }
    public string? ImageContentType { get; set; }
}

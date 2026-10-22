using Application.Core.Mediatr.Requests.UserRequest;

namespace Application.Commands.User.Character.UpdateCharacter;

// A new name and/or a new portrait, sent to the character service in one request.
public class UpdateCharacterCommand : UserRequest<bool>
{
    public Guid CharacterId { get; set; }
    public string? Name { get; set; }
    public byte[]? Image { get; set; }
    public string? ImageContentType { get; set; }
}

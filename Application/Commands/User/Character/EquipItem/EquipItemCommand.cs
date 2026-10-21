using Application.Core.Mediatr.Requests.UserRequest;

namespace Application.Commands.User.Character.EquipItem;

public class EquipItemCommand : UserRequest<bool>
{
    public Guid CharacterId { get; set; }
    public Guid ItemId { get; set; }
    public string Slot { get; set; } = string.Empty;
    public string? AccessorySlotName { get; set; }
}

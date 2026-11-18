using Application.Core.Mediatr.Requests.UserRequest;

namespace Application.Commands.User.Character.AttuneItem;

public class AttuneItemCommand : UserRequest<bool>
{
    public Guid CharacterId { get; set; }
    public Guid ItemId { get; set; }
    public bool Attune { get; set; } = true;
    // The Short Rest spent focused on the item (I-03): the client's id for this request — the same again is
    // the same rest. Out of a session an hour of campaign time apart; at a table the table's own rest counts.
    public Guid? RestId { get; set; }
}

using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Queries.User.Character.GetCharacterById;

public class GetCharacterByIdQuery : UserRequest<CharacterSheetData>
{
    public Guid Id { get; set; }
}

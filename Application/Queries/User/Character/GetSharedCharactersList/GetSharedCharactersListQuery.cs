using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;

namespace Application.Queries.User.Character.GetSharedCharactersList;

public class GetSharedCharactersListQuery : UserRequest<List<SharedCharacterRow>>
{
}

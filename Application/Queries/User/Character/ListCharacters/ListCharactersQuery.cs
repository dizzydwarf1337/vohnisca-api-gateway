using Application.Core.Mediatr.Requests.UserRequest;
using Application.Core.Responses;
using Application.Interfaces.RpcClients;

namespace Application.Queries.User.Character.ListCharacters;

public class ListCharactersQuery : UserRequest<PaginationResponse<CharacterListRow>>
{
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 50;
}

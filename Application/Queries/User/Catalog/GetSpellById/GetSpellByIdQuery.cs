using Application.Core.ApiResponse;
using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Queries.User.Catalog.GetSpellById;

public class GetSpellByIdQuery : UserRequest<SpellDetail>
{
    public Guid Id { get; set; }
}

public class GetSpellByIdQueryHandler : IRequestHandler<GetSpellByIdQuery, ApiResponse<SpellDetail>>
{
    private readonly ICharacterRpcClient _client;
    public GetSpellByIdQueryHandler(ICharacterRpcClient client) => _client = client;

    public async Task<ApiResponse<SpellDetail>> Handle(GetSpellByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _client.GetSpellById(request.Id, request.Token!);
        return result.ToApiResponse(x => x, "Error getting spell");
    }
}

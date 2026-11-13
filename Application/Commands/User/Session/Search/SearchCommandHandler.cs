using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Session.Search;

public class SearchCommandHandler : IRequestHandler<SearchCommand, ApiResponse<CombatResultData>>
{
    private readonly ISessionRpcClient _client;
    public SearchCommandHandler(ISessionRpcClient client) => _client = client;

    public async Task<ApiResponse<CombatResultData>> Handle(SearchCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.Search(request, request.Token!);
        return result.ToApiResponse(x => x, "Error: Search");
    }
}

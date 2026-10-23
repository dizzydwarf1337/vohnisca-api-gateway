using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Queries.User.Character.GetLevelUpPreview;

public class GetLevelUpPreviewQueryHandler : IRequestHandler<GetLevelUpPreviewQuery, ApiResponse<LevelUpPreviewData>>
{
    private readonly ICharacterRpcClient _client;
    public GetLevelUpPreviewQueryHandler(ICharacterRpcClient client) => _client = client;

    public async Task<ApiResponse<LevelUpPreviewData>> Handle(GetLevelUpPreviewQuery request, CancellationToken cancellationToken)
    {
        var result = await _client.GetLevelUpPreview(request, request.Token!);
        return result.ToApiResponse(x => x, "Error previewing the level");
    }
}

using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Campaign.Chapter.GrantChapterAccess;

public class GrantChapterAccessCommandHandler : IRequestHandler<GrantChapterAccessCommand, ApiResponse<Unit>>
{
    private readonly ICampaignRpcClient _campaignRpcClient;

    public GrantChapterAccessCommandHandler(ICampaignRpcClient campaignRpcClient)
        => _campaignRpcClient = campaignRpcClient;

    public async Task<ApiResponse<Unit>> Handle(GrantChapterAccessCommand request, CancellationToken cancellationToken)
    {
        var result = await _campaignRpcClient.GrantChapterAccess(request.ChapterId, request.TargetUserIds, request.Token);
        return result.ToApiResponse(_ => Unit.Value, "Error granting chapter access");
    }
}
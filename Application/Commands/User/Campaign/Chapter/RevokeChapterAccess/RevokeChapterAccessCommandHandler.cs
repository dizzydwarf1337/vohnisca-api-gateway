using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Campaign.Chapter.RevokeChapterAccess;

public class RevokeChapterAccessCommandHandler : IRequestHandler<RevokeChapterAccessCommand, ApiResponse<Unit>>
{
    private readonly ICampaignRpcClient _campaignRpcClient;

    public RevokeChapterAccessCommandHandler(ICampaignRpcClient campaignRpcClient)
        => _campaignRpcClient = campaignRpcClient;

    public async Task<ApiResponse<Unit>> Handle(RevokeChapterAccessCommand request, CancellationToken cancellationToken)
    {
        var result = await _campaignRpcClient.RevokeChapterAccess(request.ChapterId, request.TargetUserIds, request.Token);
        return result.ToApiResponse(_ => Unit.Value, "Error revoking chapter access");
    }
}
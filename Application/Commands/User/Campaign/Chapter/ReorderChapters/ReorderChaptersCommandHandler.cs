using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Campaign.Chapter.ReorderChapters;

public class ReorderChaptersCommandHandler : IRequestHandler<ReorderChaptersCommand, ApiResponse<Unit>>
{
    private readonly ICampaignRpcClient _campaignRpcClient;

    public ReorderChaptersCommandHandler(ICampaignRpcClient campaignRpcClient)
        => _campaignRpcClient = campaignRpcClient;

    public async Task<ApiResponse<Unit>> Handle(ReorderChaptersCommand request, CancellationToken cancellationToken)
    {
        var result = await _campaignRpcClient.ReorderChapters(request.CampaignId, request.ParentId, request.OrderedIds, request.UserId!.Value.ToString());
        return result.ToApiResponse(_ => Unit.Value, "Error reordering chapters");
    }
}
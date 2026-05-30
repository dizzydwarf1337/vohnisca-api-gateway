using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Campaign.Chapter.SetCurrentChapter;

public class SetCurrentChapterCommandHandler : IRequestHandler<SetCurrentChapterCommand, ApiResponse<Unit>>
{
    private readonly ICampaignRpcClient _campaignRpcClient;

    public SetCurrentChapterCommandHandler(ICampaignRpcClient campaignRpcClient)
        => _campaignRpcClient = campaignRpcClient;

    public async Task<ApiResponse<Unit>> Handle(SetCurrentChapterCommand request, CancellationToken cancellationToken)
    {
        var result = await _campaignRpcClient.SetCurrentChapter(request.CampaignId, request.ChapterId, request.Token);
        return result.ToApiResponse(_ => Unit.Value, "Error setting current chapter");
    }
}
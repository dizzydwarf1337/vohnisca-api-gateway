using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Campaign.Chapter.MoveChapter;

public class MoveChapterCommandHandler : IRequestHandler<MoveChapterCommand, ApiResponse<Unit>>
{
    private readonly ICampaignRpcClient _campaignRpcClient;

    public MoveChapterCommandHandler(ICampaignRpcClient campaignRpcClient)
        => _campaignRpcClient = campaignRpcClient;

    public async Task<ApiResponse<Unit>> Handle(MoveChapterCommand request, CancellationToken cancellationToken)
    {
        var result = await _campaignRpcClient.MoveChapter(request.ChapterId, request.NewParentId, request.Token);
        return result.ToApiResponse(_ => Unit.Value, "Error moving chapter");
    }
}
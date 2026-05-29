using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Campaign.Chapter.DeleteChapter;

public class DeleteChapterCommandHandler : IRequestHandler<DeleteChapterCommand, ApiResponse<Unit>>
{
    private readonly ICampaignRpcClient _campaignRpcClient;

    public DeleteChapterCommandHandler(ICampaignRpcClient campaignRpcClient)
        => _campaignRpcClient = campaignRpcClient;

    public async Task<ApiResponse<Unit>> Handle(DeleteChapterCommand request, CancellationToken cancellationToken)
    {
        var result = await _campaignRpcClient.DeleteChapter(request.ChapterId, request.Token!);
        return result.ToApiResponse(_ => Unit.Value, "Error deleting chapter");
    }
}
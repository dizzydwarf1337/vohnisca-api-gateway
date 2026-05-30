using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Campaign.Note.ReorderNotes;

public class ReorderNotesCommandHandler : IRequestHandler<ReorderNotesCommand, ApiResponse<Unit>>
{
    private readonly ICampaignRpcClient _campaignRpcClient;

    public ReorderNotesCommandHandler(ICampaignRpcClient campaignRpcClient)
        => _campaignRpcClient = campaignRpcClient;

    public async Task<ApiResponse<Unit>> Handle(ReorderNotesCommand request, CancellationToken cancellationToken)
    {
        var result = await _campaignRpcClient.ReorderNotes(request.ChapterId, request.OrderedIds, request.Token);
        return result.ToApiResponse(_ => Unit.Value, "Error reordering notes");
    }
}
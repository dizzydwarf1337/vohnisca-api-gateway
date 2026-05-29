using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Queries.User.Campaign.Note.GetNote;

public class GetNoteQueryHandler : IRequestHandler<GetNoteQuery, ApiResponse<NoteData>>
{
    private readonly ICampaignRpcClient _campaignRpcClient;

    public GetNoteQueryHandler(ICampaignRpcClient campaignRpcClient)
        => _campaignRpcClient = campaignRpcClient;

    public async Task<ApiResponse<NoteData>> Handle(GetNoteQuery request, CancellationToken cancellationToken)
    {
        var result = await _campaignRpcClient.GetNote(request.NoteId, request.Token!);
        return result.ToApiResponse(x => x.Note, "Error getting note");
    }
}
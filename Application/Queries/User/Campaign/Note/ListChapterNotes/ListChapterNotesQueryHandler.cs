using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Queries.User.Campaign.Note.ListChapterNotes;

public class ListChapterNotesQueryHandler : IRequestHandler<ListChapterNotesQuery, ApiResponse<List<NoteData>>>
{
    private readonly ICampaignRpcClient _campaignRpcClient;

    public ListChapterNotesQueryHandler(ICampaignRpcClient campaignRpcClient)
        => _campaignRpcClient = campaignRpcClient;

    public async Task<ApiResponse<List<NoteData>>> Handle(ListChapterNotesQuery request, CancellationToken cancellationToken)
    {
        var result = await _campaignRpcClient.ListChapterNotes(request.ChapterId, request.Token!);
        return result.ToApiResponse(x => x.Notes, "Error listing notes");
    }
}
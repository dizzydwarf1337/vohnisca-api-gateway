using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Campaign.Note.SetNoteColor;

public class SetNoteColorCommandHandler : IRequestHandler<SetNoteColorCommand, ApiResponse<NoteData>>
{
    private readonly ICampaignRpcClient _campaignRpcClient;

    public SetNoteColorCommandHandler(ICampaignRpcClient campaignRpcClient)
        => _campaignRpcClient = campaignRpcClient;

    public async Task<ApiResponse<NoteData>> Handle(SetNoteColorCommand request, CancellationToken cancellationToken)
    {
        var result = await _campaignRpcClient.SetNoteColor(request.NoteId, request.BackgroundColor, request.Token);
        return result.ToApiResponse(x => x.Note, "Failed to change the note color");
    }
}

using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Campaign.Note.CreateNote;

public class CreateNoteCommandHandler : IRequestHandler<CreateNoteCommand, ApiResponse<NoteData>>
{
    private readonly ICampaignRpcClient _campaignRpcClient;

    public CreateNoteCommandHandler(ICampaignRpcClient campaignRpcClient)
        => _campaignRpcClient = campaignRpcClient;

    public async Task<ApiResponse<NoteData>> Handle(CreateNoteCommand request, CancellationToken cancellationToken)
    {
        var result = await _campaignRpcClient.CreateNote(request.ChapterId, request.Title, request.Content, request.Token);
        return result.ToApiResponse(x => x.Note, "Error creating note");
    }
}
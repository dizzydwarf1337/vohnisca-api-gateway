using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;
using MediatR;
using Application.Core.ApiResponse;
using FluentValidation;

namespace Application.Commands.User.Campaign.Characters;

// A campaign's characters and its milestone advancement (P-06 / P-07): the campaign service decides who may
// (the master or a co-master) and tells character-service over the bus.
public class ListCampaignCharactersQuery : UserRequest<List<CampaignCharacterData>>
{
    public Guid CampaignId { get; set; }
}

public class SetHitPointsModeCommand : UserRequest<CampaignData>
{
    public Guid CampaignId { get; set; }
    // "fixed" or "roll".
    public string Mode { get; set; } = string.Empty;
}

// What the game master does with one character: grant a level, release it, admit it back.
public enum CampaignCharacterAction
{
    GrantLevelUp,
    ReleaseCampaignCharacter,
    AdmitCampaignCharacter,
}

public class CampaignCharacterCommand : UserRequest<CampaignCharacterData>
{
    public Guid CampaignId { get; set; }
    public Guid CharacterId { get; set; }
    public CampaignCharacterAction Action { get; set; }
}

public class SetHitPointsModeCommandValidator : AbstractValidator<SetHitPointsModeCommand>
{
    public SetHitPointsModeCommandValidator()
    {
        RuleFor(x => x.CampaignId).NotEmpty();
        RuleFor(x => x.Mode).Must(m => m is "fixed" or "roll").WithMessage("Hit points are \"fixed\" or \"roll\"");
    }
}

public class CampaignCharacterCommandHandlers :
    IRequestHandler<ListCampaignCharactersQuery, ApiResponse<List<CampaignCharacterData>>>,
    IRequestHandler<SetHitPointsModeCommand, ApiResponse<CampaignData>>,
    IRequestHandler<CampaignCharacterCommand, ApiResponse<CampaignCharacterData>>
{
    private readonly ICampaignRpcClient _campaigns;

    public CampaignCharacterCommandHandlers(ICampaignRpcClient campaigns) => _campaigns = campaigns;

    public async Task<ApiResponse<List<CampaignCharacterData>>> Handle(ListCampaignCharactersQuery request, CancellationToken ct)
        => (await _campaigns.ListCampaignCharacters(request.CampaignId, request.Token)).ToApiResponse(x => x.Characters, "Error listing the campaign's characters");

    public async Task<ApiResponse<CampaignData>> Handle(SetHitPointsModeCommand request, CancellationToken ct)
        => (await _campaigns.SetHitPointsMode(request.CampaignId, request.Mode, request.Token)).ToApiResponse(x => x.Campaign, "Error setting the hit points rule");

    public async Task<ApiResponse<CampaignCharacterData>> Handle(CampaignCharacterCommand request, CancellationToken ct)
        => (await _campaigns.CampaignCharacterAction(request.Action.ToString(), request.CampaignId, request.CharacterId, request.Token))
            .ToApiResponse(x => x.Character, "Error with the campaign's character");
}

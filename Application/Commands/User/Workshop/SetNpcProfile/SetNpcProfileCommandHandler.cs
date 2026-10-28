using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Workshop.SetNpcProfile;

public class SetNpcProfileCommandHandler : IRequestHandler<SetNpcProfileCommand, ApiResponse<bool>>
{
    private readonly IWorkshopRpcClient _client;
    public SetNpcProfileCommandHandler(IWorkshopRpcClient client) => _client = client;

    public async Task<ApiResponse<bool>> Handle(SetNpcProfileCommand request, CancellationToken cancellationToken)
        => (await _client.SetNpcProfile(request, request.Token!)).ToApiResponse(x => x, "Error setting the NPC profile");
}

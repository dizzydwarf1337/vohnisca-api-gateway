using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Workshop.UpdateNpcDetails;

public class UpdateNpcDetailsCommandHandler : IRequestHandler<UpdateNpcDetailsCommand, ApiResponse<bool>>
{
    private readonly IWorkshopRpcClient _client;
    public UpdateNpcDetailsCommandHandler(IWorkshopRpcClient client) => _client = client;

    public async Task<ApiResponse<bool>> Handle(UpdateNpcDetailsCommand request, CancellationToken cancellationToken)
        => (await _client.UpdateNpcDetails(request, request.Token!)).ToApiResponse(x => x, "Error updating the NPC");
}

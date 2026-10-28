using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Workshop.CreateNpc;

public class CreateNpcCommandHandler : IRequestHandler<CreateNpcCommand, ApiResponse<CreatedContent>>
{
    private readonly IWorkshopRpcClient _client;
    public CreateNpcCommandHandler(IWorkshopRpcClient client) => _client = client;

    public async Task<ApiResponse<CreatedContent>> Handle(CreateNpcCommand request, CancellationToken cancellationToken)
        => (await _client.CreateNpc(request, request.Token!)).ToApiResponse(x => x, "Error creating the NPC");
}

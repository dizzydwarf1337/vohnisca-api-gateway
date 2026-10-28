using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Workshop.AddNpcAction;

public class AddNpcActionCommandHandler : IRequestHandler<AddNpcActionCommand, ApiResponse<NpcActionAdded>>
{
    private readonly IWorkshopRpcClient _client;
    public AddNpcActionCommandHandler(IWorkshopRpcClient client) => _client = client;

    public async Task<ApiResponse<NpcActionAdded>> Handle(AddNpcActionCommand request, CancellationToken cancellationToken)
        => (await _client.AddNpcAction(request, request.Token!)).ToApiResponse(x => x, "Error adding the action");
}

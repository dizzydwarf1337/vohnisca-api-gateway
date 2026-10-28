using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Workshop.CreateItem;

public class CreateWorkshopItemCommandHandler : IRequestHandler<CreateWorkshopItemCommand, ApiResponse<CreatedContent>>
{
    private readonly IWorkshopRpcClient _client;
    public CreateWorkshopItemCommandHandler(IWorkshopRpcClient client) => _client = client;

    public async Task<ApiResponse<CreatedContent>> Handle(CreateWorkshopItemCommand request, CancellationToken cancellationToken)
        => (await _client.CreateItem(request, request.Token!)).ToApiResponse(x => x, "Error creating item");
}

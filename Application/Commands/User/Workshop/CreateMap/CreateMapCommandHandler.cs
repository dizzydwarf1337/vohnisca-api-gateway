using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Workshop.CreateMap;

public class CreateMapCommandHandler : IRequestHandler<CreateMapCommand, ApiResponse<CreatedContent>>
{
    private readonly IWorkshopRpcClient _client;
    public CreateMapCommandHandler(IWorkshopRpcClient client) => _client = client;

    public async Task<ApiResponse<CreatedContent>> Handle(CreateMapCommand request, CancellationToken cancellationToken)
        => (await _client.CreateMap(request, request.Token!)).ToApiResponse(x => x, "Error creating the map");
}

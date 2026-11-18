using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Character.ExpendCharges;

public class ExpendChargesCommandHandler : IRequestHandler<ExpendChargesCommand, ApiResponse<bool>>
{
    private readonly ICharacterRpcClient _client;
    public ExpendChargesCommandHandler(ICharacterRpcClient client) => _client = client;

    public async Task<ApiResponse<bool>> Handle(ExpendChargesCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.ExpendCharges(request, request.Token!);
        return result.ToApiResponse(x => x, "Error spending charges");
    }
}

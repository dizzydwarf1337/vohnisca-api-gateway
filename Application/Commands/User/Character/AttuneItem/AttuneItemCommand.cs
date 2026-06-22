using Application.Core.ApiResponse;
using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.Character.AttuneItem;

public class AttuneItemCommand : UserRequest<bool>
{
    public Guid CharacterId { get; set; }
    public Guid ItemId { get; set; }
    public bool Attune { get; set; } = true;
}

public class AttuneItemCommandHandler : IRequestHandler<AttuneItemCommand, ApiResponse<bool>>
{
    private readonly ICharacterRpcClient _client;
    public AttuneItemCommandHandler(ICharacterRpcClient client) => _client = client;

    public async Task<ApiResponse<bool>> Handle(AttuneItemCommand request, CancellationToken cancellationToken)
    {
        var result = await _client.AttuneItem(request, request.Token!);
        return result.ToApiResponse(x => x, "Error attuning item");
    }
}

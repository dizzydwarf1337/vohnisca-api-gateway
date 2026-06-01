using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.User.DeleteProfilePicture;

public class DeleteProfilePictureCommandHandler : IRequestHandler<DeleteProfilePictureCommand, ApiResponse<Unit>>
{
    private readonly IUserRpcClient _userRpcClient;

    public DeleteProfilePictureCommandHandler(IUserRpcClient userRpcClient)
        => _userRpcClient = userRpcClient;

    public async Task<ApiResponse<Unit>> Handle(DeleteProfilePictureCommand command,
        CancellationToken cancellationToken)
    {
        var rpcResult = await _userRpcClient.DeleteProfilePicture(command.Token);
        return rpcResult.ToApiResponse(_ => Unit.Value, "Error while deleting profile picture");
    }
}
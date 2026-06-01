using Application.Core.Mediatr.Requests.UserRequest;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.User.UpdateUserData;

public class UpdateUserDataCommand : UserRequest<Unit>
{
    public UpdateUserDataRequest UserData { get; set; }
}
using Application.Core.Mediatr.Requests.PublicRequest;
using Application.Interfaces.RpcClients;

namespace Application.Commands.Public.Auth.Login;

public class LoginCommand : PublicRequest<LoginResult>
{
    public string Email { get; set; }
    public string Password { get; set; }
    
}
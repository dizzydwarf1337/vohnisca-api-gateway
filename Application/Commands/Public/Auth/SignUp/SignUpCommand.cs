using Application.Core.Mediatr.Requests.PublicRequest;
using Application.Interfaces.GrpcClients;

namespace Application.Commands.Public.Auth.SignUp;

public class SignUpCommand : PublicRequest<SignUpResult>
{
    public string Email;
    public string Password;
    public string Password_confimation;
    public string name;
}
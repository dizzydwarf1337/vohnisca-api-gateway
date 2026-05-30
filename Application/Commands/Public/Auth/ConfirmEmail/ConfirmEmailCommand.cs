using Application.Core.Mediatr.Requests.PublicRequest;
using MediatR;

namespace Application.Commands.Public.Auth.ConfirmEmail;

public class ConfirmEmailCommand : PublicRequest<Unit>
{
    public string UserMail { get; set; }
    public string Token { get; set; }
}
using Application.Core.Mediatr.Requests.AdminRequest;
using MediatR;

namespace Application.Commands.Admin.Mail;

public class SendMailCommand : AdminRequest<Unit>
{
    public string Email { get; set; }
    public string Subject { get; set; }
    public string Content { get; set; }
}
using Application.Commands.Admin.Mail;
using Microsoft.AspNetCore.Mvc;

namespace vohnisca_api_gateway.Controllers.Admin;

[Route("admin/mail")]
public class MailController : BaseController
{
    [HttpPost]
    [Route("send")]
    public async Task<IActionResult> SendMail(SendMailCommand command)
        => HandleResponse(await Mediator.Send(command));
}
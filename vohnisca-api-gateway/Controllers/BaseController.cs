using Application.Core.ApiResponse;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace vohnisca_api_gateway.Controllers;

[Route("api")]
[ApiController]
public class BaseController : Controller
{
    private IMediator? _mediator;
    private IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<IMediator>();

    protected async Task<IActionResult> HandleResponse<T>(IRequest<ApiResponse<T>> command)
    {
        var result = await Send(command);
        return StatusCode(result.StatusCode, result);
    }

    // For an action whose answer is not the envelope — a picture, which the browser wants as bytes.
    protected async Task<ApiResponse<T>> Send<T>(IRequest<ApiResponse<T>> request)
    {
        var result = await Mediator.Send(request);
        // A service's JSON-RPC error code (-32603…) is no HTTP status: Kestrel would write it into
        // the status line as is and the ingress would drop the answer ("protocol error").
        if (result.StatusCode is < 100 or > 599) result.StatusCode = 502;
        return result;
    }
}
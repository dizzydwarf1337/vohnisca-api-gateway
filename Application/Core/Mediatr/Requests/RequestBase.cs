using Application.Core.ApiResponse;
using MediatR;

namespace Application.Core.Mediatr.Requests;

public class RequestBase<T> : IRequest<ApiResponse<T>>
{
    public bool IsSysRequest { get; set; }
    public Guid? CorrelationId { get; set; }
}
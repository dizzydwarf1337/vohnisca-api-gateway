using Application.Core.ApiResponse;
using FluentValidation;
using MediatR;

namespace Application.Core.Mediatr.Behaviors;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        => _validators = validators;

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (!_validators.Any())
            return await next(cancellationToken);

        var context = new ValidationContext<TRequest>(request);
        var failures = (await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken))))
            .SelectMany(r => r.Errors)
            .Where(e => e != null)
            .ToList();

        if (failures.Count == 0)
            return await next(cancellationToken);

        var error = string.Join("; ", failures.Select(f => f.ErrorMessage));

        if (ApiResponse<object>.Failure(error) is TResponse r)
            return r;

        return await next(cancellationToken);
    }
}
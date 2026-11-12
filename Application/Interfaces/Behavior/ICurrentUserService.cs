namespace Application.Interfaces.Behavior;

public interface ICurrentUserService
{
    Guid? UserId { get; }
    string? Token { get; }

    // The request's Idempotency-Key header, when the client sent one.
    string? IdempotencyKey { get; }
}
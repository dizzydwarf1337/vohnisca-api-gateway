namespace Application.Interfaces.Behavior;

public interface ICurrentUserService
{
    Guid? UserId { get; }
    string? Token { get; }
}
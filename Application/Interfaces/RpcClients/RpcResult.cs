namespace Application.Interfaces.RpcClients;

public record RpcResult<T>(bool IsSuccess, T? Data, string? Error);
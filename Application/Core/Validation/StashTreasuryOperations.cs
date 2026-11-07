namespace Application.Core.Validation;

// What a treasury call does: the campaign service has one RPC per direction, the gateway route is one.
public static class StashTreasuryOperations
{
    public const string Add = "add";
    public const string Spend = "spend";

    public static bool IsKnown(string? operation) => operation is Add or Spend;
}
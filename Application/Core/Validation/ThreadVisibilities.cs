namespace Application.Core.Validation;

// Who a thread is written for: everybody in the campaign, or the game masters only.
public static class ThreadVisibilities
{
    public const string All = "all";
    public const string GameMasters = "gm";

    public static bool IsKnown(string? visibility) => visibility is All or GameMasters;
}
namespace Application.Core.Validation;

// The coin names a campaign treasury knows (meta.coins of a stash card). A request may name only some
// of them: the campaign service adds up what was sent and treats an absent denomination as zero.
public static class CoinDenominations
{
    public static readonly string[] All = ["cp", "sp", "ep", "gp", "pp"];

    public static bool IsKnown(string key) => All.Contains(key);
}
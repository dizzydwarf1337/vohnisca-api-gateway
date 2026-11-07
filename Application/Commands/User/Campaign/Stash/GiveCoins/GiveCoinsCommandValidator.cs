using Application.Core.Validation;
using FluentValidation;

namespace Application.Commands.User.Campaign.Stash.GiveCoins;

public class GiveCoinsCommandValidator : AbstractValidator<GiveCoinsCommand>
{
    public GiveCoinsCommandValidator()
    {
        RuleFor(x => x.CardId).NotEmpty();
        RuleFor(x => x.CharacterId).NotEmpty();
        RuleFor(x => x.Coins).NotEmpty();
        RuleForEach(x => x.Coins).Must(coin => CoinDenominations.IsKnown(coin.Key))
            .WithMessage($"Coins hold {string.Join(", ", CoinDenominations.All)} only.");
        RuleForEach(x => x.Coins).Must(coin => coin.Value >= 0)
            .WithMessage("A coin count cannot be negative.");
    }
}
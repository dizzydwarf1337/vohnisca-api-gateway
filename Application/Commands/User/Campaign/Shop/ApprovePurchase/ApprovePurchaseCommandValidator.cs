using FluentValidation;

namespace Application.Commands.User.Campaign.Shop.ApprovePurchase;

public class ApprovePurchaseCommandValidator : AbstractValidator<ApprovePurchaseCommand>
{
    public ApprovePurchaseCommandValidator()
    {
        RuleFor(x => x.PurchaseId).NotEmpty();
    }
}
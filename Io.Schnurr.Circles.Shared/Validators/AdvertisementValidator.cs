using FluentValidation;
using Io.Schnurr.Circles.Shared.Models;

namespace Io.Schnurr.Circles.Shared.Validators;


public class AdvertisementValidator : BaseValidator<Advertisement>
{
    public AdvertisementValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .Length(10, 50);

        RuleFor(x => x.Description)
            .NotEmpty()
            .Length(100, 10000);

        RuleFor(x => x.Price)
            .NotEmpty()
            .InclusiveBetween(0, 999999.99M)
            .PrecisionScale(8, 2, true);

        RuleFor(x => x.Condition)
            .IsInEnum();

        RuleFor(x => x.Base64Image)
            .NotEmpty();
    }
}
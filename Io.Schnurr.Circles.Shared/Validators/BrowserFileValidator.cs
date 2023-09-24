using FluentValidation;
using Io.Schnurr.Circles.Shared.Models;

namespace Io.Schnurr.Circles.Shared.Validators;


public class BrowserFileValidator : BaseValidator<BrowserFile>
{
    public BrowserFileValidator()
    {
        RuleFor(x => x.File)
            .NotEmpty();

        When(x => x.File != null, () =>
        {
            RuleFor(x => x.File.Name)
              .NotEmpty();

            RuleFor(x => x.File.Size)
            .LessThanOrEqualTo(10485760)
            .WithMessage("The maximum file size is 10 MB");
        });
    }
}
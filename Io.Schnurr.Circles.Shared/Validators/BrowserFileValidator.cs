using FluentValidation;
using Io.Schnurr.Circles.Shared.Models;

namespace Io.Schnurr.Circles.Shared.Validators;


public class BrowserFileValidator : BaseValidator<BrowserFile>
{
    public BrowserFileValidator()
    {
        RuleFor(x => x.Name)
          .NotEmpty()
          .WithMessage("'File' must not be empty.");

        RuleFor(x => x.Size)
        .LessThanOrEqualTo(10485760)
        .WithMessage("The maximum file size is 10 MB");

        RuleFor(x => x.Base64File)
          .NotEmpty();
    }
}
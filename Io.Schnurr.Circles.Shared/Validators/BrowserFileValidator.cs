using FluentValidation;
using Io.Schnurr.Circles.Shared.Models;

namespace Io.Schnurr.Circles.Shared.Validators;


public class BrowserFileValidator : BaseValidator<BrowserFile>
{
    public BrowserFileValidator()
    {
        //TODO: SHOW Correct file validataion for IBRowserFile and regular file
        // Validate Base64 File
        When(x => x.File == null, () =>
        {
            RuleFor(x => x.Name)
              .NotEmpty();

            RuleFor(x => x.Base64File)
              .NotEmpty();

            RuleFor(x => x.Size)
            .LessThanOrEqualTo(10485760)
            .WithMessage("The maximum file size is 10 MB");
        });

        // Validate IBrowserFile
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
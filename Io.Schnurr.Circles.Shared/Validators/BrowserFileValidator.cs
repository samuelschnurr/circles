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

        RuleFor(x => x.ContentType)
             .Must(BeValidImageType)
             .WithMessage("Invalid file type. Please select JPG, JPEG, or PNG files.");

        RuleFor(x => x.Base64File)
          .NotEmpty();
    }

    private bool BeValidImageType(string contentType)
    {
        var validMimeTypes = new[] { "image/jpeg", "image/png" };
        return validMimeTypes.Contains(contentType);
    }
}
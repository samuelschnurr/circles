using FluentValidation;
using Io.Schnurr.Circles.App.Utils;
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
        .LessThanOrEqualTo(Helpers.MaxFileSize)
        .WithMessage("The maximum file size is 2,5 MB");

        RuleFor(x => x.ContentType)
             .Must(BeValidImageType)
             .WithMessage("Invalid file type. Please select JPG, JPEG, or PNG files.");

        RuleFor(x => x.Base64Content)
          .NotEmpty()
          .When(x => x.ByteContent == null || x.ByteContent.Length <= 0);

        RuleFor(x => x.ByteContent)
          .NotEmpty()
          .When(x => string.IsNullOrEmpty(x.Base64Content));
    }

    private bool BeValidImageType(string contentType)
    {
        var validMimeTypes = new[] { "image/jpeg", "image/png" };
        return validMimeTypes.Contains(contentType);
    }
}
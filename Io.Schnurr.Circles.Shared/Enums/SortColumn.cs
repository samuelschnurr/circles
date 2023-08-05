using System.ComponentModel.DataAnnotations;

namespace Io.Schnurr.Circles.Shared.Enums;

public enum SortColumn
{
    [Display(Name = "Creation date")]
    CreatedAt,
    Title,
    Price
}

using System.ComponentModel.DataAnnotations;

namespace Io.Schnurr.Circles.Shared.Enums;

public enum AdvertisementCondition
{
    New,
    [Display(Name = "Very Good")]
    VeryGood,
    Good,
    Acceptable
}

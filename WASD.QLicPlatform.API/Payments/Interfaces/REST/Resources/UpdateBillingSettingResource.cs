using System.ComponentModel.DataAnnotations;

namespace WASD.QLicPlatform.API.Payments.Interfaces.REST.Resources;

public record UpdateBillingSettingResource(
    [Required] bool Autopay,
    [Required] bool EmailNotifications,
    [Required] 
    [RegularExpression("^(yearly|monthly)$", ErrorMessage = "BillingCycle must be 'yearly' or 'monthly'")]
    string BillingCycle,
    [Required]
    [Range(1, 31, ErrorMessage = "PreferredBillingDay must be between 1 and 31")]
    int PreferredBillingDay
);


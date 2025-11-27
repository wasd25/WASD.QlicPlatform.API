using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WASD.QLicPlatform.API.Payments.Domain.Model.Aggregates;

public class BillingSetting
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Required]
    public bool Autopay { get; set; }
    
    [Required]
    public bool EmailNotifications { get; set; }
    
    [Required]
    [MaxLength(20)]
    public string BillingCycle { get; set; } = "monthly";
    
    [Required]
    [Range(1, 31)]
    public int PreferredBillingDay { get; set; }
    
    [Required]
    public DateTime LastUpdate { get; set; }
    
    // User ID reference (assuming you have user management)
    public int? UserId { get; set; }
}


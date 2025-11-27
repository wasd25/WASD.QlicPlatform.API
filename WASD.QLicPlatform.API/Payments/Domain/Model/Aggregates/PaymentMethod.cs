using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WASD.QLicPlatform.API.Payments.Domain.Model.Aggregates;

public class PaymentMethod
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string Type { get; set; } = string.Empty;
    
    [Required]
    [MaxLength(255)]
    public string Details { get; set; } = string.Empty;
    
    [Required]
    public bool IsDefault { get; set; }
}


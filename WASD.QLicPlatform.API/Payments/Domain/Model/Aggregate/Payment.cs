namespace WASD.QLicPlatform.API.Payments.Domain.Model.Aggregate;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Payment
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Required]
    [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than 0")]
    public decimal Amount { get; set; }
    
    [Required]
    public DateTime Date { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string Status { get; set; } = string.Empty;
    
    [Required]
    public int MethodId { get; set; }
}

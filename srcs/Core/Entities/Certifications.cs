using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace university_management_service.srcs.Core.Entities;

public class Certifications
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long CertificationId { get; set; }
    
    [ForeignKey(nameof(Student))]
    [MaxLength(20)]
    public string StudentNIC { get; set; } = "";
    
    [Required]
    [MaxLength(100)]
    public string CertificateName { get; set; } = "";
    
    [Required]
    [MaxLength(50)]
    public string Category { get; set; } = "";
    
    [MaxLength(500)]
    public string? Description { get; set; }
    
    [Required]
    public string CertificateHtmlContent { get; set; } = "";
    
    public DateTime IssuedDate { get; set; } = DateTime.UtcNow;
    
    public Student? Student { get; set; }
}

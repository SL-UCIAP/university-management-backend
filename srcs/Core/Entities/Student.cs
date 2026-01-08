using System.ComponentModel.DataAnnotations;

namespace university_management_service.srcs.Core.Entities;

public class Student
{
    [Key]
    [MaxLength(20)]
    public string NIC { get; set; } = "";
    
    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = "";
    
    [Required]
    public DateOnly BirthDate { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string Email { get; set; } = "";
    
    [MaxLength(15)]
    public string? PhoneNumber { get; set; }
    
    [MaxLength(200)]
    public string? Address { get; set; }
    
    public DateTime RegisteredDate { get; set; } = DateTime.UtcNow;
    
    public ICollection<Certifications> Certifications { get; set; } = new List<Certifications>();
    public ICollection<Result> Results { get; set; } = new List<Result>();
}

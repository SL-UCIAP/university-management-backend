using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace university_management_service.srcs.Core.Entities;

public class Result
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ResultId { get; set; }
    
    [ForeignKey(nameof(Student))]
    [MaxLength(20)]
    public string StudentNIC { get; set; } = "";
    
    [ForeignKey(nameof(Module))]
    public int ModuleId { get; set; }
    
    public int Year { get; set; }
    
    [Range(0.0, 4.0)]
    public double Gpa { get; set; }
    
    [MaxLength(10)]
    public string Grade { get; set; } = "";
    
    public Student? Student { get; set; }
    public Module? Module { get; set; }
}

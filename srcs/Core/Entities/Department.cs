using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace university_management_service.srcs.Core.Entities;

public class Department
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int DepartmentId { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = "";
    
    [Required]
    [MaxLength(100)]
    public string FacultyName { get; set; } = "";
    
    public ICollection<Lecture> Lectures { get; set; } = new List<Lecture>();
}

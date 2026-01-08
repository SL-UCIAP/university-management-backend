using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace university_management_service.srcs.Core.Entities;

public class Lecture
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int LectureId { get; set; }
    
    [ForeignKey(nameof(Department))]
    public int LectureNumber { get; set; }
    
    [MaxLength(100)]
    public string Name { get; set; } = "";
    [MaxLength(60)]
    public string Email { get; set; } = "";
    
    public Department? Department { get; set; }
}

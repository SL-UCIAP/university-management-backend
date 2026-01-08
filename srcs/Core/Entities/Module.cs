using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace university_management_service.srcs.Core.Entities;

public class Module
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ModuleId { get; set; }
    [MaxLength(50)]
    public string Name { get; set; } = "";
    [MaxLength(50)]
    public string Credits { get; set; } = "";
    
    public ICollection<Result>  Results { get; set; } = new List<Result>();
}

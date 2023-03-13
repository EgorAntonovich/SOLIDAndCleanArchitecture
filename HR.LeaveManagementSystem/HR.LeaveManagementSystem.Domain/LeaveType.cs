using System.ComponentModel.DataAnnotations;
using HR.LeaveManagementSystem.Domain.Common;

namespace HR.LeaveManagementSystem.Domain;

public class LeaveType : BaseEntity
{
    [Required]
    [StringLength(70)]
    public string Name { get; set; } = string.Empty;
    
    public int DefaultDays { get; set; }
}
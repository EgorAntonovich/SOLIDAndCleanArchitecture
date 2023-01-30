using System.ComponentModel.DataAnnotations;

namespace HR.LeaveManagement.MVC.Models.LeaveType;

public class CreateLeaveTypeViewModel
{
    [Required]
    public string Name { get; set; }
    
    [Required]
    [Display(Name = "Default Number of Days")]
    public int DefaultDays { get; set; }
}
﻿using HR.LeaveManagementSystem.Domain.Common;

namespace HR.LeaveManagementSystem.Domain;

public class LeaveRequest : BaseEntity
{
    public DateTime StartDay { get; set; }

    public DateTime EndDate { get; set; }
    
    public LeaveType? LeaveType { get; set; }
    
    public int LeaveTypeId { get; set; }
    
    public DateTime DateRequested { get; set; }
    
    public string? RequestComments { get; set; }
    
    public bool? Approved { get; set; }
    
    public bool Cancelled { get; set; }

    public string RequestingEmployeeId { get; set; } = string.Empty;
}
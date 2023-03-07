﻿namespace HR.LeaveManagementSystem.Application.Features.LeaveTypeCQRS.Queries.GetAllLeaveTypes;

public class LeaveTypeDto
{
    public int Id { get; set; }
    
    public string Name { get; set; } = string.Empty;

    public int DefaultDays { get; set; }
}
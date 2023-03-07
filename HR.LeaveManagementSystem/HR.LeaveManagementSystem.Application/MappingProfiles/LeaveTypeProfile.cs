using AutoMapper;
using HR.LeaveManagementSystem.Application.Features.LeaveTypeCQRS.Queries.GetAllLeaveTypes;
using HR.LeaveManagementSystem.Domain;

namespace HR.LeaveManagementSystem.Application.MappingProfiles;

public class LeaveTypeProfile : Profile
{
    public LeaveTypeProfile()
    {
        CreateMap<LeaveTypeDto, LeaveType>().ReverseMap();
    }
}
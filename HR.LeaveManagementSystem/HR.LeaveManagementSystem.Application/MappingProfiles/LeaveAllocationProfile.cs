using AutoMapper;
using HR.LeaveManagementSystem.Application.Features.LeaveAllocationCQRS.Queries.GetAllLeaveAllocations;
using HR.LeaveManagementSystem.Domain;

namespace HR.LeaveManagementSystem.Application.MappingProfiles;

public class LeaveAllocationProfile : Profile
{
    public LeaveAllocationProfile()
    {
        CreateMap<LeaveAllocationDto, LeaveAllocation>().ReverseMap();
    }
}
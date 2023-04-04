using AutoMapper;
using HR.LeaveManagementSystem.Application.Features.LeaveAllocationCQRS.Commands.CreateLeaveAllocation;
using HR.LeaveManagementSystem.Application.Features.LeaveAllocationCQRS.Commands.UpdateLeaveAllocation;
using HR.LeaveManagementSystem.Application.Features.LeaveAllocationCQRS.Queries.GetAllLeaveAllocations;
using HR.LeaveManagementSystem.Application.Features.LeaveAllocationCQRS.Queries.GetLeaveAllocationDetails;
using HR.LeaveManagementSystem.Domain;

namespace HR.LeaveManagementSystem.Application.MappingProfiles;

public class LeaveAllocationProfile : Profile
{
    public LeaveAllocationProfile()
    {
        CreateMap<LeaveAllocationDto, LeaveAllocation>().ReverseMap();
        CreateMap<LeaveAllocation, LeaveAllocationDetailsDto>().ReverseMap();
        CreateMap<CreateLeaveAllocationCommand, LeaveAllocation>();
        CreateMap<UpdateLeaveAllocationCommand, LeaveAllocation>();
    }
}
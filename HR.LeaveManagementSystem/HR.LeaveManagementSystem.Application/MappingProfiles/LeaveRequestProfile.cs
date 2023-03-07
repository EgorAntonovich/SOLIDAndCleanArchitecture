using AutoMapper;
using HR.LeaveManagementSystem.Application.Features.LeaveRequestCQRS.Queries.GetAllLeaveRequests;
using HR.LeaveManagementSystem.Domain;

namespace HR.LeaveManagementSystem.Application.MappingProfiles;

public class LeaveRequestProfile : Profile
{
    public LeaveRequestProfile()
    {
        CreateMap<LeaveRequestDto, LeaveRequest>().ReverseMap();
    }
}
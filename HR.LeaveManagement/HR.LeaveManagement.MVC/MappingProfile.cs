using AutoMapper;
using HR.LeaveManagement.MVC.Models.LeaveType;
using HR.LeaveManagement.MVC.Services.Base;

namespace HR.LeaveManagement.MVC;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateLeaveTypeDto, CreateLeaveTypeViewModel>().ReverseMap();
        CreateMap<LeaveTypeDto, LeaveTypeViewModel>().ReverseMap();
    }
}
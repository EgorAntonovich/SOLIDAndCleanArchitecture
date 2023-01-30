using HR.LeaveManagement.MVC.Models.LeaveType;
using HR.LeaveManagement.MVC.Services.Base;

namespace HR.LeaveManagement.MVC.Contracts;

public interface ILeaveTypeService
{
    Task<List<LeaveTypeViewModel>> GetLeaveTypes();
    Task<LeaveTypeViewModel> GetLeaveTypeDetails(int id);
    Task<Response<int>> CreateLeaveType(CreateLeaveTypeViewModel leaveTypeViewModel);
    Task<Response<int>> UpdateLeaveTypes(int id, LeaveTypeViewModel leaveTypeViewModel);
    Task<Response<int>> DeleteLEaveType(int id);
}
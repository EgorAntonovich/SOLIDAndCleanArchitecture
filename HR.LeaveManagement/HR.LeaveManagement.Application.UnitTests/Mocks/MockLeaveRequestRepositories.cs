using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using Moq;

namespace HR.LeaveManagement.Application.UnitTests.Mocks;

public class MockLeaveRequestRepositories
{
    public static Mock<ILeaveRequestRepository> GetLeaveRequestRepository()
    {
        var leaveType = new LeaveType()
        {
            DefaultDays = 10,
            Id = 1,
            Name = "This is Teeeeeest!"
        };
        var leaveRequests = new List<Domain.LeaveRequest>()
        {
            new()
            {
                LeaveType = leaveType,
                LeaveTypeId = 1,
                RequestComments = "Hello",
                Approved = true,
                Cancelled = false
            },
            new()
            {
                LeaveType = leaveType,
                LeaveTypeId = 2,
                RequestComments = "Hello how",
                Approved = false,
                Cancelled = false
            },
            new()
            {
                LeaveType = leaveType,
                LeaveTypeId = 3,
                RequestComments = "Hello how are you",
                Approved = true,
                Cancelled = true
            }
        };


        var moqRepo = new Mock<ILeaveRequestRepository>();
        
        moqRepo.Setup(r => r.GetAll()).ReturnsAsync(leaveRequests);
        moqRepo.Setup(r => r.Get(It.IsAny<int>())).ReturnsAsync(leaveRequests.First());
        moqRepo.Setup(r => r.Update(It.IsAny<LeaveRequest>())).Returns(Task.CompletedTask);
        moqRepo.Setup(r => r.Delete(It.IsAny<LeaveRequest>())).Returns((LeaveRequest leaveTypeDelete) =>
        {
            leaveRequests.Remove(leaveTypeDelete);
            return Task.CompletedTask;
        });

        moqRepo.Setup(r => r.Add(It.IsAny<LeaveRequest>())).ReturnsAsync((LeaveRequest leaveTypeAdd) =>
        {
            leaveRequests.Add(leaveTypeAdd);
            return leaveTypeAdd;
        });
        
        return moqRepo;
    }
}
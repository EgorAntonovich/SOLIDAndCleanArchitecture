using HR.LeaveManagementSystem.Application.Contracts.Persistence;
using HR.LeaveManagementSystem.Domain;
using Moq;

namespace HR.LeaveManagementSystem.Application.UnitTests.Mocks;

public class MockLeaveRequestRepository
{
    public static Mock<ILeaveRequestRepository> GetLeaveRequestMockLeaveRequestRepository()
    {
        var leaveTypes = new List<LeaveType>()
        {
            new LeaveType()
            {
                Id = 1,
                DefaultDays = 10,
                Name = "Test Vacation"
            },
            new LeaveType()
            {
                Id = 2,
                DefaultDays = 15,
                Name = "Test Sick"
            },
            new LeaveType()
            {
                Id = 3,
                DefaultDays = 20,
                Name = "Test Maternity"
            }
        };

        var leaveRequests = new List<LeaveRequest>()
        {
            new LeaveRequest()
            {
                LeaveType = leaveTypes.Find(x => x.Id == 1),
                LeaveTypeId = 1,
                RequestComments = "Test comment",
                Approved = true,
                Cancelled = false,
            },
            new LeaveRequest()
            {
                LeaveType = leaveTypes.Find(x => x.Id == 2),
                LeaveTypeId = 2,
                RequestComments = "Test Second",
                Approved = true,
                Cancelled = false,
            },
            new LeaveRequest()
            {
                LeaveType = leaveTypes.Find(x => x.Id == 3),
                LeaveTypeId = 3,
                RequestComments = "Test third",
                Approved = true,
                Cancelled = false,
            }
        };

        var mockRepo = new Mock<ILeaveRequestRepository>();
        mockRepo.Setup(r => r.GetAsync()).ReturnsAsync(leaveRequests);
        mockRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(leaveRequests.First);
        mockRepo.Setup(r => r.CreateAsync(It.IsAny<LeaveRequest>())).Returns((LeaveRequest leaveRequest) =>
        {
            leaveRequests.Add(leaveRequest);
            return Task.CompletedTask;
        });

        return mockRepo;
    }
}
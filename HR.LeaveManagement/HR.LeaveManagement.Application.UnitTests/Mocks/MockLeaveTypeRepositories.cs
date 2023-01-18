using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using Moq;

namespace HR.LeaveManagement.Application.UnitTests.Mocks;

public class MockLeaveTypeRepositories
{
    public static Mock<ILeaveTypeRepository> GetLeaveTypeRepository()
    {
        int id = 1;
        var leaveType = new LeaveType
        {
            Id = 1,
            DefaultDays = 10,
            Name = "Test Vacation"
        };
        var leaveTypes = new List<LeaveType>
        {
            new LeaveType
            {
                Id = 1,
                DefaultDays = 10,
                Name = "Test Vacation"
            },
            new LeaveType
            {
                Id = 2,
                DefaultDays = 15,
                Name = "Test Sick"
            },
            new LeaveType
            {
                Id = 3,
                DefaultDays = 15,
                Name = "Test Maternity"
            }
        };

        var moqRepo = new Mock<ILeaveTypeRepository>();

        moqRepo.Setup(r => r.GetAll()).ReturnsAsync(leaveTypes);

        moqRepo.Setup(r => r.Get(id)).ReturnsAsync(leaveType);

        moqRepo.Setup(r => r.Add(It.IsAny<LeaveType>())).ReturnsAsync((LeaveType leaveType) =>
        {
            leaveTypes.Add(leaveType);
            return leaveType;
        });

        return moqRepo;
    }
}
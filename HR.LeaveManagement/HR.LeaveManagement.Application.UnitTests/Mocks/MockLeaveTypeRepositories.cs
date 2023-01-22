using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using Moq;

namespace HR.LeaveManagement.Application.UnitTests.Mocks;

public class MockLeaveTypeRepositories
{
    public static Mock<ILeaveTypeRepository> GetLeaveTypeRepository()
    {
        var leaveTypes = new List<LeaveType>
        {
            new () { Id = 1, DefaultDays = 10, Name = "Test Vacation" },
            new () { Id = 2, DefaultDays = 15, Name = "Test Sick" },
            new () { Id = 3, DefaultDays = 15, Name = "Test Maternity" }
        };

        var moqRepo = new Mock<ILeaveTypeRepository>();

        moqRepo.Setup(r => r.GetAll()).ReturnsAsync(leaveTypes);
        moqRepo.Setup(r => r.Get(It.IsAny<int>())).ReturnsAsync(leaveTypes.First());
        moqRepo.Setup(r => r.Update(It.IsAny<LeaveType>())).Returns(Task.CompletedTask);
        moqRepo.Setup(r => r.Delete(It.IsAny<LeaveType>())).Returns((LeaveType leaveTypeDelete) =>
        {
            leaveTypes.Remove(leaveTypeDelete);
            return Task.CompletedTask;
        });

        moqRepo.Setup(r => r.Add(It.IsAny<LeaveType>())).ReturnsAsync((LeaveType leaveTypeAdd) =>
        {
            leaveTypes.Add(leaveTypeAdd);
            return leaveTypeAdd;
        });

        return moqRepo;
    }
}
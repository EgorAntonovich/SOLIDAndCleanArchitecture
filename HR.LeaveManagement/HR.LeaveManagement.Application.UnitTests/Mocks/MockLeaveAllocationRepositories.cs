using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using Moq;

namespace HR.LeaveManagement.Application.UnitTests.Mocks;

public class MockLeaveAllocationRepositories
{
    public static Mock<ILeaveAllocationRepository> GetLeaveAllocationRepository()
    {
        var leaveType = new LeaveType()
        {
            Id = 1,
            DefaultDays = 40,
            Name = "Test For Test"
        };
        
        
        var leaveAllocations = new List<LeaveAllocation>
        {
            new()
            {
                NumberOfDays = 7,
                LeaveType = leaveType,
                LeaveTypeId = 1,
                Period = 10
            },
            new()
            {
                NumberOfDays = 11,
                LeaveType = leaveType,
                LeaveTypeId = 2,
                Period = 15
            },
            new()
            {
                NumberOfDays = 10,
                LeaveType = leaveType,
                LeaveTypeId = 3,
                Period = 20
            }
        };

        var moqRepo = new Mock<ILeaveAllocationRepository>();
        
        moqRepo.Setup(r => r.GetAll()).ReturnsAsync(leaveAllocations);
        moqRepo.Setup(r => r.Get(It.IsAny<int>())).ReturnsAsync(leaveAllocations.First());
        moqRepo.Setup(r => r.Add(It.IsAny<LeaveAllocation>())).ReturnsAsync((LeaveAllocation leaveAllocationAdd) =>
        {
            leaveAllocations.Add(leaveAllocationAdd);
            return leaveAllocationAdd;
        });

        return moqRepo;
    }
}
using HR.LeaveManagementSystem.Application.Contracts.Persistence;
using HR.LeaveManagementSystem.Domain;
using Moq;

namespace HR.LeaveManagementSystem.Application.UnitTests.Mocks;

public class MockLeaveAllocationRepository
{
    public static Mock<ILeaveAllocationRepository> GetLeaveAllocationMockLeaveAllocationRepository()
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


        var leaveAllocations = new List<LeaveAllocation>()
        {
            new LeaveAllocation()
            {
                Id = 1,
                NumberOfDays = 10,
                LeaveType = leaveTypes[0],
                LeaveTypeId = 1,
                Period = 15,
                EmployeeId = string.Empty,
            },
            new LeaveAllocation()
            {
                Id = 2,
                NumberOfDays = 20,
                LeaveType = leaveTypes[1],
                LeaveTypeId = 2,
                Period = 1,
                EmployeeId = string.Empty,
            },
            new LeaveAllocation()
            {
                Id = 3,
                NumberOfDays = 5,
                LeaveType = leaveTypes[2],
                LeaveTypeId = 3,
                Period = 4,
                EmployeeId = string.Empty,
            }
        };

        var mockRepo = new Mock<ILeaveAllocationRepository>();
        mockRepo.Setup(r => r.GetAsync()).ReturnsAsync(leaveAllocations);
        mockRepo.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(leaveAllocations.First);
        mockRepo.Setup(r => r.CreateAsync(It.IsAny<LeaveAllocation>()))
            .Returns((LeaveAllocation leaveAllocation) => 
            { 
                leaveAllocations.Add(leaveAllocation); 
                return Task.CompletedTask; 
            });

        return mockRepo;
    }
}
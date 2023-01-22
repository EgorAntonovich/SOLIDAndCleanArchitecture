using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Features.LeaveTypes.Handlers.Commands;
using HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Commands;
using HR.LeaveManagement.Application.UnitTests.Mocks;
using MediatR;
using Moq;
using Shouldly;
using Xunit;

namespace HR.LeaveManagement.Application.UnitTests.LeaveTypes.Commands;

public class DeleteLeaveTypeCommandHandlerTests
{
    private readonly Mock<ILeaveTypeRepository> _mockRepo;
    private readonly DeleteLeaveTypeCommandHandler _handler;

    public DeleteLeaveTypeCommandHandlerTests()
    {
        _mockRepo = MockLeaveTypeRepositories.GetLeaveTypeRepository();
        _handler = new DeleteLeaveTypeCommandHandler(_mockRepo.Object);
    }

    [Fact]
    public async Task Valid_LeaveType_Deleted()
    {
        var result = await _handler.Handle(new DeleteLeaveTypeCommand { Id = 1 }, CancellationToken.None);
        var leaveTypes = await _mockRepo.Object.GetAll();
        
        result.ShouldBeOfType<Unit>();
        leaveTypes.Count.ShouldBe(2);
    }

    [Fact]
    public async Task InValid_LeaveType_Deleted()
    {
        ValidationException ex = await Should.ThrowAsync<ValidationException>
        (
            async () => await _handler.Handle(new DeleteLeaveTypeCommand() { Id = 5 },
                CancellationToken.None)
        );
        
        ex.ShouldNotBeNull();
    }
}
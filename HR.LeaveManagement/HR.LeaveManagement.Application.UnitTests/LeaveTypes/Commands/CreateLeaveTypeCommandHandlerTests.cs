using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Contracts.Persistence.DTOs.LeaveType;
using HR.LeaveManagement.Application.Contracts.Persistence.Features.LeaveTypes.Handlers.Commands;
using HR.LeaveManagement.Application.Contracts.Persistence.Features.LeaveTypes.Requests.Commands;
using HR.LeaveManagement.Application.Contracts.Persistence.Profiles;
using HR.LeaveManagement.Application.UnitTests.Mocks;
using Moq;
using Shouldly;
using Xunit;

namespace HR.LeaveManagement.Application.UnitTests.LeaveTypes.Commands;

public class CreateLeaveTypeCommandHandlerTests
{
    private readonly IMapper _mapper;
    private readonly Mock<ILeaveTypeRepository> _mockRepo;
    private readonly CreateLeaveTypeDto _leaveTypeDto;

    public CreateLeaveTypeCommandHandlerTests()
    {
        _mockRepo = MockLeaveTypeRepositories.GetLeaveTypeRepository();
        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<MappingProfile>();
        });

        _mapper = mapperConfig.CreateMapper();
        _leaveTypeDto = new CreateLeaveTypeDto
        {
            DefaultDays = 15,
            Name = "Test DTO"
        };
    }

    [Fact]
    public async Task Valid_LeaveType_Added()
    {
        var handler = new CreateLeaveTypeCommandHandler(_mockRepo.Object, _mapper);

        var result = await handler.Handle(new CreateLeaveTypeCommand() {LeaveType = _leaveTypeDto}, CancellationToken.None);

        var leaveTypes = await _mockRepo.Object.GetAll();
        
        result.ShouldBeOfType<int>();
        leaveTypes.Count.ShouldBe(4);
    }
}
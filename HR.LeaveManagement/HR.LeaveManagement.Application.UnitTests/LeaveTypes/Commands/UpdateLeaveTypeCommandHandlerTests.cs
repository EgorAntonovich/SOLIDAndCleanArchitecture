using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.DTOs.LeaveType;
using HR.LeaveManagement.Application.Features.LeaveTypes.Handlers.Commands;
using HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Commands;
using HR.LeaveManagement.Application.Profiles;
using HR.LeaveManagement.Application.Responses;
using HR.LeaveManagement.Application.UnitTests.Mocks;
using Moq;
using Shouldly;
using Xunit;

namespace HR.LeaveManagement.Application.UnitTests.LeaveTypes.Commands;

public class UpdateLeaveTypeCommandHandlerTests
{
    private readonly IMapper _mapper;
    private readonly Mock<ILeaveTypeRepository> _mockRepo;
    private readonly UpdateLeaveTypeCommandHandler _handler;
    private readonly LeaveTypeDto _leaveTypeDto;

    public UpdateLeaveTypeCommandHandlerTests()
    {
        _mockRepo = MockLeaveTypeRepositories.GetLeaveTypeRepository();
        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<MappingProfile>();
        });

        _mapper = mapperConfig.CreateMapper();
        _handler = new UpdateLeaveTypeCommandHandler(_mockRepo.Object, _mapper);
        _leaveTypeDto = new LeaveTypeDto
        {
            Id = 3,
            DefaultDays = 20,
            Name = "Test Test"
        };
    }

    [Fact]
    public async Task Valid_LeaveType_Updated()
    {
        var result = await _handler.Handle(new UpdateLeaveTypeCommand {LeaveType = _leaveTypeDto}, CancellationToken.None);

        var updateLeaveType = await _mockRepo.Object.Get(_leaveTypeDto.Id);
        
        result.ShouldBeOfType<BaseCommandResponse>();
        updateLeaveType.Id.ShouldBe(3);
        updateLeaveType.Name.ShouldBe("Test Test");
        updateLeaveType.DefaultDays.ShouldBe(20);
    }

    [Fact]
    public async Task InValid_LeaveType_Updated()
    {
        _leaveTypeDto.DefaultDays = 101;

        var handleResult = await _handler.Handle(new UpdateLeaveTypeCommand { LeaveType = _leaveTypeDto },
            CancellationToken.None);


        var leaveTypes = await _mockRepo.Object.GetAll();
        
        leaveTypes.Count.ShouldBe(3);
        handleResult.IsSuccess.ShouldBe(true);
        handleResult.Errors.ShouldNotBeEmpty();
    }
}
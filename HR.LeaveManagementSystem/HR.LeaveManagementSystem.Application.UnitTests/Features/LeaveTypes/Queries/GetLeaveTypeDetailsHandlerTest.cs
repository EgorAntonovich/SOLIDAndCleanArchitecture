using AutoMapper;
using HR.LeaveManagementSystem.Application.Contracts.Logging;
using HR.LeaveManagementSystem.Application.Contracts.Persistence;
using HR.LeaveManagementSystem.Application.Features.LeaveTypeCQRS.Queries.GetAllLeaveTypes;
using HR.LeaveManagementSystem.Application.Features.LeaveTypeCQRS.Queries.GetLeaveTypeDetails;
using HR.LeaveManagementSystem.Application.MappingProfiles;
using HR.LeaveManagementSystem.Application.UnitTests.Mocks;
using Moq;
using Shouldly;

namespace HR.LeaveManagementSystem.Application.UnitTests.Features.LeaveTypes.Queries;

public class GetLeaveTypeDetailsHandlerTest
{
    private readonly Mock<ILeaveTypeRepository> _mockRepo;
    private readonly IMapper _mapper;
    private readonly Mock<IAppLogger<GetLeaveTypeDetailsQueryHandler>> _appLogger;
    
    public GetLeaveTypeDetailsHandlerTest()
    {
        _mockRepo = MockLeaveTypeRepository.GetLeaveTypeMockLeaveTypeRepository();

        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<LeaveTypeProfile>();
        });

        _mapper = mapperConfig.CreateMapper();
        _appLogger = new Mock<IAppLogger<GetLeaveTypeDetailsQueryHandler>>();
    }

    [Fact]
    public async Task GetLeaveTypeDetailsTest()
    {
        var handler = new GetLeaveTypeDetailsQueryHandler(_mockRepo.Object, _mapper, _appLogger.Object);

        var result = await handler.Handle(new GetLeaveTypeDetailsQuery(1), CancellationToken.None);
        
        result.ShouldBeOfType<LeaveTypeDetailsDto>();
        result.Name.ShouldBe("Test Vacation");
    }
}
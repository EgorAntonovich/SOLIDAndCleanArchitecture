using AutoMapper;
using HR.LeaveManagementSystem.Application.Contracts.Logging;
using HR.LeaveManagementSystem.Application.Contracts.Persistence;
using HR.LeaveManagementSystem.Application.Features.LeaveRequestCQRS.Queries.GetAllLeaveRequests;
using HR.LeaveManagementSystem.Application.MappingProfiles;
using HR.LeaveManagementSystem.Application.UnitTests.Mocks;
using Moq;
using Shouldly;

namespace HR.LeaveManagementSystem.Application.UnitTests.Features.LeaveRequests.Queries;

public class GetLeaveRequestsQueryHandlerTests
{
    private readonly Mock<ILeaveRequestRepository> _mockRepo;
    private readonly IMapper _mapper;
    private readonly Mock<IAppLogger<GetLeaveRequestsQueryHandler>> _appLogger;
    
    public GetLeaveRequestsQueryHandlerTests()
    {
        _mockRepo = MockLeaveRequestRepository.GetLeaveRequestMockLeaveRequestRepository();

        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<LeaveRequestProfile>();
        });

        _mapper = mapperConfig.CreateMapper();
        _appLogger = new Mock<IAppLogger<GetLeaveRequestsQueryHandler>>();
    }

    [Fact]
    public async Task GetLeaveRequestsTest()
    {
        var handler = new GetLeaveRequestsQueryHandler(_mockRepo.Object, _mapper, _appLogger.Object);

        var result = await handler.Handle(new GetLeaveRequestsQuery(), CancellationToken.None);
        
        result.ShouldBeOfType<List<LeaveRequestDto>>();
        result.Count.ShouldBe(3);
    }
}
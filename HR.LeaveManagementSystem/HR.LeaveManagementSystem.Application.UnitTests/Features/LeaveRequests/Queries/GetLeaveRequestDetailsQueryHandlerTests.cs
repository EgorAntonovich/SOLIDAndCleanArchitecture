using AutoMapper;
using HR.LeaveManagementSystem.Application.Contracts.Logging;
using HR.LeaveManagementSystem.Application.Contracts.Persistence;
using HR.LeaveManagementSystem.Application.Features.LeaveAllocationCQRS.Queries.GetLeaveAllocationDetails;
using HR.LeaveManagementSystem.Application.Features.LeaveRequestCQRS.Queries.GetLeaveRequestDetails;
using HR.LeaveManagementSystem.Application.MappingProfiles;
using HR.LeaveManagementSystem.Application.UnitTests.Mocks;
using Moq;
using Shouldly;

namespace HR.LeaveManagementSystem.Application.UnitTests.Features.LeaveRequests.Queries;

public class GetLeaveRequestDetailsQueryHandlerTests
{
    private readonly Mock<ILeaveRequestRepository> _mockRepo;
    private readonly IMapper _mapper;
    private readonly Mock<IAppLogger<GetLeaveRequestDetailsQueryHandler>> _appLogg;

    public GetLeaveRequestDetailsQueryHandlerTests()
    {
        _mockRepo = MockLeaveRequestRepository.GetLeaveRequestMockLeaveRequestRepository();

        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<LeaveRequestProfile>();
        });

        _mapper = mapperConfig.CreateMapper();
        _appLogg = new Mock<IAppLogger<GetLeaveRequestDetailsQueryHandler>>();
    }

    [Fact]
    public async Task GetLeaveRequestDetailsTest()
    {
        var handler = new GetLeaveRequestDetailsQueryHandler(_mockRepo.Object, _mapper, _appLogg.Object);
        var result = await handler.Handle(new GetLeaveRequestDetailsQuery() {Id = 1}, CancellationToken.None);

        result.ShouldBeOfType<LeaveRequestDetailsDto>();
        result.Approved.ShouldBe(true);
    }
}
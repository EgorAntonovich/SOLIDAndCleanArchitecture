using AutoMapper;
using HR.LeaveManagementSystem.Application.Contracts.Logging;
using HR.LeaveManagementSystem.Application.Contracts.Persistence;
using HR.LeaveManagementSystem.Application.Features.LeaveAllocationCQRS.Queries.GetAllLeaveAllocations;
using HR.LeaveManagementSystem.Application.Features.LeaveRequestCQRS.Queries.GetAllLeaveRequests;
using HR.LeaveManagementSystem.Application.MappingProfiles;
using HR.LeaveManagementSystem.Application.UnitTests.Mocks;
using Moq;
using Shouldly;

namespace HR.LeaveManagementSystem.Application.UnitTests.Features.LeaveAllocations.Queries;

public class GetLeaveAllocationsQueryHandlerTests
{
    private readonly Mock<ILeaveAllocationRepository> _mockRepo;
    private readonly IMapper _mapper;
    private readonly Mock<IAppLogger<GetLeaveAllocationsQueryHandler>> _appLogger;

    public GetLeaveAllocationsQueryHandlerTests()
    {
        _mockRepo = MockLeaveAllocationRepository.GetLeaveAllocationMockLeaveAllocationRepository();

        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<LeaveAllocationProfile>();
        });

        _mapper = mapperConfig.CreateMapper();
        _appLogger = new Mock<IAppLogger<GetLeaveAllocationsQueryHandler>>();
    }

    [Fact]
    public async Task GetLeaveRequestsTest()
    {
        var handler = new GetLeaveAllocationsQueryHandler(_mockRepo.Object, _mapper);
        var result = await handler.Handle(new GetLeaveAllocationsQuery(), CancellationToken.None);

        result.ShouldBeOfType<List<LeaveAllocationDto>>();
        result.Count.ShouldBe(3);
    }
}
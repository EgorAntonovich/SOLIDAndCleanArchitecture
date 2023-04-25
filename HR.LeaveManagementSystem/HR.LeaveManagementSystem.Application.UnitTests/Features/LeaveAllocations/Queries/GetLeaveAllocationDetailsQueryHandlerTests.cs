using AutoMapper;
using HR.LeaveManagementSystem.Application.Contracts.Logging;
using HR.LeaveManagementSystem.Application.Contracts.Persistence;
using HR.LeaveManagementSystem.Application.Features.LeaveAllocationCQRS.Queries.GetLeaveAllocationDetails;
using HR.LeaveManagementSystem.Application.MappingProfiles;
using HR.LeaveManagementSystem.Application.UnitTests.Mocks;
using Moq;
using Shouldly;

namespace HR.LeaveManagementSystem.Application.UnitTests.Features.LeaveAllocations.Queries;

public class GetLeaveAllocationDetailsQueryHandlerTests
{
    private readonly Mock<ILeaveAllocationRepository> _mockRepo;
    private readonly IMapper _mapper;
    private readonly Mock<IAppLogger<GetLeaveAllocationDetailsQueryHandler>> _appLogg;

    public GetLeaveAllocationDetailsQueryHandlerTests()
    {
        _mockRepo = MockLeaveAllocationRepository.GetLeaveAllocationMockLeaveAllocationRepository();

        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<LeaveAllocationProfile>();
        });

        _mapper = mapperConfig.CreateMapper();
        _appLogg = new Mock<IAppLogger<GetLeaveAllocationDetailsQueryHandler>>();
    }

    [Fact]
    public async Task GetLeaveAllocationDetailsTest()
    {
        var handler = new GetLeaveAllocationDetailsQueryHandler(_mockRepo.Object, _mapper);
        var result = await handler.Handle(new GetLeaveAllocationDetailsQuery() {Id = 1}, CancellationToken.None);

        result.ShouldBeOfType<LeaveAllocationDetailsDto>();
        result.NumberOfDays.ShouldBe(10);
    }
}
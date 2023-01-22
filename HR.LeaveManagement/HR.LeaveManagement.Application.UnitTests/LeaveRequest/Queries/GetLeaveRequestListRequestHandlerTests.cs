using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.DTOs.LeaveRequest;
using HR.LeaveManagement.Application.DTOs.LeaveType;
using HR.LeaveManagement.Application.Features.LeaveRequests.Handlers.Queries;
using HR.LeaveManagement.Application.Features.LeaveRequests.Requests.Queries;
using HR.LeaveManagement.Application.Features.LeaveTypes.Handlers.Queries;
using HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Queries;
using HR.LeaveManagement.Application.Profiles;
using HR.LeaveManagement.Application.UnitTests.Mocks;
using Moq;
using Shouldly;
using Xunit;

namespace HR.LeaveManagement.Application.UnitTests.LeaveRequest.Queries;

public class GetLeaveRequestListRequestHandlerTests
{
    private readonly IMapper _mapper;
    private readonly Mock<ILeaveRequestRepository> _mockRepo;

    public GetLeaveRequestListRequestHandlerTests()
    {
        _mockRepo = MockLeaveRequestRepositories.GetLeaveRequestRepository();
        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<MappingProfile>();
        });

        _mapper = mapperConfig.CreateMapper();
    }

    [Fact]
    public async Task GetLeaveTyListTest()
    {
        var handler = new GetLeaveRequestRequestHandler(_mockRepo.Object, _mapper);
        var result = await handler.Handle(new GetLeaveRequestListRequest(), CancellationToken.None);
        result.ShouldBeOfType<List<LeaveRequestDto>>();
        result.Count.ShouldBe(3);
    }
}
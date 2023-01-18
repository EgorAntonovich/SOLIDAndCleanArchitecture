using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.DTOs.LeaveType;
using HR.LeaveManagement.Application.Features.LeaveTypes.Handlers.Queries;
using HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Queries;
using HR.LeaveManagement.Application.Profiles;
using HR.LeaveManagement.Application.UnitTests.Mocks;
using Moq;
using Shouldly;
using Xunit;

namespace HR.LeaveManagement.Application.UnitTests.LeaveTypes.Queries;

public class GetLeaveTypeDetailRequestHandlerTests
{
    private readonly IMapper _mapper;
    private readonly Mock<ILeaveTypeRepository> _mockRepo;

    public GetLeaveTypeDetailRequestHandlerTests()
    {
        _mockRepo = MockLeaveTypeRepositories.GetLeaveTypeRepository();

        var mapperConfig = new MapperConfiguration(c =>
        {
            c.AddProfile<MappingProfile>();
        });

        _mapper = mapperConfig.CreateMapper();
    }

    [Fact]
    public async Task GetLeaveTypeDetailTest()
    {
        const int id = 1;
        var handler = new GetLeaveTypeDetailRequestHandler(_mockRepo.Object, _mapper);
        var result = await handler.Handle(new GetLeaveTypeDetailRequest { Id = id }, CancellationToken.None);
        
        result.ShouldBeOfType<LeaveTypeDto>();
        result.ShouldNotBeNull();
    }
}
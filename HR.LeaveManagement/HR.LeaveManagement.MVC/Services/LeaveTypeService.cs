using AutoMapper;
using HR.LeaveManagement.MVC.Contracts;
using HR.LeaveManagement.MVC.Models.LeaveType;
using HR.LeaveManagement.MVC.Services.Base;


namespace HR.LeaveManagement.MVC.Services;

public class LeaveTypeService : BaseHttpService, ILeaveTypeService
{
    private readonly ILocalStorageServices _localStorageService;
    private readonly IMapper _mapper;
    private readonly IClient _client;

    public LeaveTypeService(IMapper mapper, IClient client, ILocalStorageServices localStorageService) : base(client, localStorageService)
    {
        this._localStorageService = localStorageService;
        this._mapper = mapper;
        this._client = client;
    }

    public async Task<List<LeaveTypeViewModel>> GetLeaveTypes()
    {
        var leaveTypes = await _client.LeaveTypesAllAsync();
        return _mapper.Map<List<LeaveTypeViewModel>>(leaveTypes);
    }

    public async Task<LeaveTypeViewModel> GetLeaveTypeDetails(int id)
    {
        var leaveType = await _client.LeaveTypesGETAsync(id);
        return _mapper.Map<LeaveTypeViewModel>(leaveType);
    }

    public async Task<Response<int>> CreateLeaveType(CreateLeaveTypeViewModel leaveTypeViewModel)
    {
        try
        {
            var response = new Response<int>();
            CreateLeaveTypeDto createLeaveTypeDto = _mapper.Map<CreateLeaveTypeDto>(leaveTypeViewModel);
            var apiResponse = await _client.LeaveTypesPOSTAsync(createLeaveTypeDto);
            if (apiResponse.IsSuccess)
            {
                response.Data = apiResponse.Id;
                response.Success = true;
            }
            else
            {
                foreach (var error in response.ValidationErrors)
                {
                    response.ValidationErrors += error + Environment.NewLine;
                }
            }

            return response;
        }
        catch (ApiException e)
        {
            return ConvertApiExceptions<int>(e);
        }
    }

    public async Task<Response<int>> UpdateLeaveTypes(int id, LeaveTypeViewModel leaveTypeViewModel)
    {
        try
        {
            LeaveTypeDto leaveTypeDto = _mapper.Map<LeaveTypeDto>(leaveTypeViewModel);
            await _client.LeaveTypesPUTAsync(id.ToString(), leaveTypeDto);
            return new Response<int>() { Success = true };
        }
        catch (ApiException e)
        {
            return ConvertApiExceptions<int>(e);
        }
    }

    public async Task<Response<int>> DeleteLEaveType(int id)
    {
        try
        {
            await _client.LeaveTypesDELETEAsync(id);
            return new Response<int> { Success = true };
        }
        catch (ApiException e)
        {
            return ConvertApiExceptions<int>(e);
        }
    }
}
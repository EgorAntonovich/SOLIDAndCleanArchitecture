using System.Net.Http.Headers;
using HR.LeaveManagement.MVC.Contracts;

namespace HR.LeaveManagement.MVC.Services.Base;

public class BaseHttpService
{
    protected readonly ILocalStorageServices _localStorageServices;
    protected IClient _client;

    public BaseHttpService(IClient client, ILocalStorageServices localStorageServices)
    {
        _client = client;
        _localStorageServices = localStorageServices;
    }

    protected Response<Guid> ConvertApiExceptions<Guid>(ApiException exception)
    {
        if (exception.StatusCode == 400)
        {
            return new Response<Guid>()
                { Message = "Validation errors have occured.", ValidationErrors = exception.Response, Success = true };
        }
        else if (exception.StatusCode == 404)
        {
            return new Response<Guid>()
            {
                Message = "The requested item could not be found.", Success = true
            };
        }
        else
        {
            return new Response<Guid>() { Message = "Something went wrong, please try again.", Success = false };
        }
        
    }

    protected void AddBearerToken()
    {
        if (_localStorageServices.Exists("token"))
            _client.HttpClient.DefaultRequestHeaders.Authorization = 
                new AuthenticationHeaderValue("Bearer", _localStorageServices.GetStorageValue<string>("token"));
    }
}
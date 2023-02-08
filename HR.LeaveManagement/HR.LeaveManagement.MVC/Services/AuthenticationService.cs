using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using HR.LeaveManagement.MVC.Contracts;
using HR.LeaveManagement.MVC.Services.Base;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using IAuthenticationService = HR.LeaveManagement.MVC.Contracts.IAuthenticationService;

namespace HR.LeaveManagement.MVC.Services;

public class AuthenticationService : BaseHttpService,IAuthenticationService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private JwtSecurityTokenHandler _tokenHandler;

    public AuthenticationService(
        IClient client,
        ILocalStorageServices localStorageServices,
        IHttpContextAccessor httpContextAccessor) : base(client, localStorageServices)
    {
        this._httpContextAccessor = httpContextAccessor;
        this._tokenHandler = new JwtSecurityTokenHandler();
    }

    public async Task<bool> Authenticate(string email, string password)
    {
        try
        {
            AuthRequest authRequest = new AuthRequest() { Email = email, Password = password };
            var authResponse = await _client.LoginAsync(authRequest);

            if (authResponse.Token != string.Empty)
            {
                var tokenContent = _tokenHandler.ReadJwtToken(authResponse.Token);
                var claims = ParseClaim(tokenContent);
                var user = new ClaimsPrincipal(new ClaimsIdentity(claims,
                    CookieAuthenticationDefaults.AuthenticationScheme));
                var login = _httpContextAccessor.HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme, user);
                _localStorageServices.SetStorageValue("token", authResponse.Token);

                return true;
            }

            return false;
        }
        catch
        {
            return false;
        }
    }

    public async Task<bool> Register(string firstName, string lastName, string userName, string email, string password)
    {
        RegistrationRequest registrationRequest = new()
        {
            FirsName = firstName,
            LastName = lastName,
            Email = email,
            UserName = userName,
            Password = password,
        };

        var response = await _client.RegisterAsync(registrationRequest);
        
        return !string.IsNullOrEmpty(response.UserId);
    }

    public async Task Logout()
    {
        _localStorageServices.ClearStorage(new List<string>() { "token" });
        await _httpContextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    }

    private IList<Claim> ParseClaim(JwtSecurityToken tokenContent)
    {
        var claims = tokenContent.Claims.ToList();
        claims.Add(new Claim(ClaimTypes.Name, tokenContent.Subject));
        return claims;
    }
}
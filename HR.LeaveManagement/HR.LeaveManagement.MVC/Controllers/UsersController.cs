using HR.LeaveManagement.MVC.Contracts;
using HR.LeaveManagement.MVC.Models;
using HR.LeaveManagement.MVC.Models.LeaveType;
using Microsoft.AspNetCore.Mvc;

namespace HR.LeaveManagement.MVC.Controllers;

public class UsersController : Controller
{
    private readonly IAuthenticationService _authenticationService;

    public UsersController(IAuthenticationService authenticationService)
    {
        this._authenticationService = _authenticationService;
    }
    
    // GET
    public IActionResult Login(string returnUrl = null)
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel login, string returnUrl)
    {
        returnUrl ??= Url.Content("~/");
        var isLoggedIn = await _authenticationService.Authenticate(login.Email, login.Password);
        if (isLoggedIn)
            return LocalRedirect(returnUrl);
        
        ModelState.AddModelError("", "Log In Attempt failed. Please try Again");
        return View(login);
    }

    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Register(RegisterViewModel registration)
    {
        throw new NotImplementedException();
    }
    
    [HttpPost]
    public async Task<IActionResult> Logout(string returnUrl)
    {
        returnUrl ??= Url.Content("~/");
        await _authenticationService.Logout();
        return LocalRedirect(returnUrl);
    }
}
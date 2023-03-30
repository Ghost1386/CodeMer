using System.Globalization;
using System.Security.Claims;
using CodeMer.BusinessLogic.Interfaces;
using CodeMer.Common.DTO;
using CodeMer.Common.DTO.AuthDto;
using CodeMer.Models.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CodeMer.Controllers;

public class AuthController : Controller
{
    private readonly ILogger<AuthController> _logger;
    private readonly IAuthService _authService;

    public AuthController(ILogger<AuthController> logger, IAuthService authService)
    {
        _logger = logger;
        _authService = authService;
    }

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(AuthUserDto authUserDto)
    {
        return RedirectToAction("SelectLanguage", "Home");
        if (_authService.Login(authUserDto, out User user))
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Surname, user.Surname),
                new Claim(ClaimTypes.Locality, user.Town),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };

            var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimIdentity));
                
            _logger.LogInformation($"{DateTime.Now.ToString(CultureInfo.CurrentCulture)}: user with " +
                                   $"email {user.Email} is signed id.");

            return RedirectToAction("SelectLanguage", "Home");
        }
        
        return RedirectToAction("SelectLanguage", "Home");
    }
    
    public IActionResult Registration()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult Registration(RegistrationUserDto registrationUserDto)
    {
        if (_authService.Registration(registrationUserDto))
        {
            return View("Login");
        }

        var errorsDto = new ErrorsDto
        {
            StatusCode = 415,
            Message = "Unsupported Media Type"
        };
        
        return RedirectToAction("Errors", "Errors", errorsDto);
    }

    public IActionResult ResetPassword()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult ResetPassword(ResetPasswordUserDto resetPasswordUserDto)
    {
        _authService.ResetPassword(resetPasswordUserDto);

        return View("Login");
    }
    
    [Authorize]
    public async Task<IActionResult> LogOut()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

        return RedirectToAction("Login", "Auth");
    }
}
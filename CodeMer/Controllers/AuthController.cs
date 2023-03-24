using CodeMer.BusinessLogic.Interfaces;
using CodeMer.Common.DTO.AuthDto;
using Microsoft.AspNetCore.Mvc;

namespace CodeMer.Controllers;

public class AuthController : Controller
{
    private readonly ILogger<AuthController> _logger;

    public AuthController(ILogger<AuthController> logger)
    {
        _logger = logger;
        
    }

    public IActionResult Login()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult Login(AuthUserDto authUserDto)
    {
        return Ok();
    }
}
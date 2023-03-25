using CodeMer.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CodeMer.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ICompilerService _compilerService;

    public HomeController(ILogger<HomeController> logger, ICompilerService compilerService)
    {
        _logger = logger;
        _compilerService = compilerService;
    }
    
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return RedirectToAction("Login", "Auth");
    }
}
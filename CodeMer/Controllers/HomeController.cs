using System.Diagnostics;
using System.Text;
using CodeMer.BusinessLogic.Interfaces;
using CodeMer.Common.DTO.CompilerDto;
using Microsoft.AspNetCore.Mvc;
using CodeMer.Models;

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
    
    [HttpPost]
    public IActionResult Compiler(RequestCompilerDto requestCompilerDto)
    {
        var response = _compilerService.Compiler(requestCompilerDto);

        return Ok(response.Message);
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
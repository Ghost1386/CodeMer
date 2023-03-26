using System.Globalization;
using CodeMer.BusinessLogic.Interfaces;
using CodeMer.Common.DTO.CompilerDto;
using Microsoft.AspNetCore.Mvc;

namespace CodeMer.Controllers;

public class CompilerController : Controller
{
    private readonly ILogger<CompilerController> _logger;
    private readonly ICompilerService _compilerService;

    public CompilerController(ILogger<CompilerController> logger, ICompilerService compilerService)
    {
        _logger = logger;
        _compilerService = compilerService;
    }
    
    [HttpPost]
    public IActionResult Compiler(RequestCompilerDto requestCompilerDto)
    {
        var response = _compilerService.Compiler(requestCompilerDto);
        
        if (response.StatusCode == 200)
        {
            return Ok(response.Message);
        }
        
        _logger.LogError($"{DateTime.Now.ToString(CultureInfo.CurrentCulture)}: {response.Message}");

        return RedirectToAction("Errors", "Errors");
    }
}
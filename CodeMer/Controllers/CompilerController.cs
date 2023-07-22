using System.Globalization;
using System.Security.Claims;
using CodeMer.BusinessLogic.Interfaces;
using CodeMer.Common.DTO.ProblemDto;
using Microsoft.AspNetCore.Mvc;

namespace CodeMer.Controllers;

public class CompilerController : Controller
{
    private readonly ILogger<CompilerController> _logger;
    private readonly ICompilerService _compilerService;
    private readonly IProblemService _problemService;

    public CompilerController(ILogger<CompilerController> logger, ICompilerService compilerService, IProblemService problemService)
    {
        _logger = logger;
        _compilerService = compilerService;
        _problemService = problemService;
    }
    
    [HttpPost]
    public IActionResult Compiler(GetProblemDto requestCompilerDto)
    {
        requestCompilerDto.UserEmail = User.FindFirstValue(ClaimTypes.Email);
        requestCompilerDto.ProblemId = IProblemService.ProblemId;
        
        var response = _compilerService.Compiler(requestCompilerDto);
        
        if (response.StatusCode == 200)
        {
            return Ok(response.Message);
        }
        
        _logger.LogError($"{DateTime.Now.ToString(CultureInfo.CurrentCulture)}: {response.Message}");

        return RedirectToAction("Errors", "Errors");
    }
}
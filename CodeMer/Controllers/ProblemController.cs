using System.Security.Claims;
using CodeMer.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CodeMer.Controllers;

public class ProblemController : Controller
{
    private readonly ILogger<ProblemController> _logger;
    private readonly IProblemService _problemService;

    public ProblemController(ILogger<ProblemController> logger, IProblemService problemService)
    {
        _logger = logger;
        _problemService = problemService;
    }
    
    public IActionResult Problems()
    {
        var userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));

        return View(_problemService.GetAll(userId));
    }
}
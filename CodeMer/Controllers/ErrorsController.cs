using System.Globalization;
using CodeMer.Common.DTO;
using Microsoft.AspNetCore.Mvc;

namespace CodeMer.Controllers;

public class ErrorsController : Controller
{
    private readonly ILogger<ErrorsController> _logger;

    public ErrorsController(ILogger<ErrorsController> logger)
    {
        _logger = logger;
    }

    public IActionResult Errors(ErrorsDto errorsDto)
    {
        _logger.LogError($"{DateTime.Now.ToString(CultureInfo.CurrentCulture)}: {errorsDto.Message}");
        
        return View(errorsDto);
    }
}
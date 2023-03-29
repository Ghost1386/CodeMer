using CodeMer.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CodeMer.Controllers;

public class HomeController : Controller
{
    public IActionResult SelectLanguage()
    {
        return View();
    }
}
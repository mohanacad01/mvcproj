using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using demoproject.Models;

namespace demoproject.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Dashboard()
    {
        return View();
    }

    public IActionResult ManageCourses()
    {
        return View();
    }

    public IActionResult ManageSessions()
    {
        return View();
    }

    public IActionResult ManageUsers()
    {
        return View();
    }
    
    public IActionResult Reports()
    {
        return View();
    }

    public IActionResult Settings()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

using CoreRDLCReport.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CoreRDLCReport.Controllers;

public class HomeController : Controller
{
    private readonly IWebHostEnvironment _webHostEnvironment;

    public HomeController(IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
    }

    public IActionResult Index()
    {
        return View();
    }
    public IActionResult Print()
    {
        string mimeType = "";
        int exention = 1;
        var path = $"{this._webHostEnvironment.WebRootPath}\\Reports\\TestReport.rdlc";

        Dictionary<string, string> parameters = new Dictionary<string, string>();
        parameters.Add("title", "Test RDLC report");

        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
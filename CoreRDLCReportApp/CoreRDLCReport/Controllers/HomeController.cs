using AspNetCore.Reporting;
using CoreRDLCReport.Models;
using CoreRDLCReport.ReportDataSet;
using Microsoft.AspNetCore.Mvc;
using System.Data;
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
        var dt = new DataTable();
        dt = GetEmployeeList();

        string mimeType = "";
        int exention = 1;
        var path = $"{this._webHostEnvironment.WebRootPath}\\Reports\\TestReport.rdlc";

        Dictionary<string, string> parameters = new Dictionary<string, string>();
        parameters.Add("title", "Test RDLC report");

        LocalReport localReport = new LocalReport(path);
        localReport.AddDataSource("dsEmployee",dt);


        var result = localReport.Execute(RenderType.Pdf, exention, parameters, mimeType);

        return File(result.MainStream, "application/pdf");
    }

    public DataTable GetEmployeeList()
    {
        DataTable dt = new();
        dt.Columns.Add("EmpId");
        dt.Columns.Add("EmpName");
        dt.Columns.Add("Designation");
        dt.Columns.Add("Department");

        DataRow row;
        for (int i = 101; i < 120; i++)
        {
            row = dt.NewRow() ;

            row["EmpId"] = i;
            row["EmpName"] =  $"Name {i}";
            row["Designation"] = $"Designation {i}";
            row["Department"] = $"Department {i}";

            dt.Rows.Add(row);  
        }
        return dt;
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
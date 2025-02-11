using Microsoft.AspNetCore.Mvc;
namespace dotnetTodo.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet("/todos")]
    public IActionResult Todos()
    {
        return View();
    }

    [HttpGet("/add")]
    public IActionResult AddTodo()
    {
        return View();
    }
}
using Microsoft.AspNetCore.Mvc;
namespace dotnetTodo.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Todos()
    {
        return View();
    }

    public IActionResult AddTodo()
    {
        return View();
    }
}
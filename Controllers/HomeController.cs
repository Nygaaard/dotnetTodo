using Microsoft.AspNetCore.Mvc;
using dotnetTodo.Models;

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

    [HttpPost]
    public IActionResult AddTodo(TodoModel model)
    {
        if (ModelState.IsValid)
        {

        }
        else
        {

        }
        return View();
    }

}

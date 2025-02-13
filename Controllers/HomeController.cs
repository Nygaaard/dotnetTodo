using Microsoft.AspNetCore.Mvc;
using dotnetTodo.Models;
using System.Text.Json;
using Microsoft.AspNetCore.Http;

namespace dotnetTodo.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        ViewBag.Message = "Välkommen till din Todo-applikation!";
        return View();
    }

    public IActionResult Todos()
    {
        // Läs in todos
        string jsonStr = System.IO.File.ReadAllText("todos.json");
        // Deserialisera JSON
        var todos = JsonSerializer.Deserialize<List<TodoModel>>(jsonStr);

        // Lagra todos i session
        HttpContext.Session.SetString("Todos", jsonStr);

        // Returnera vy
        return View(todos);
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
            // Läs in todos från session
            string jsonStr = HttpContext.Session.GetString("Todos") ?? "[]";
            var todos = JsonSerializer.Deserialize<List<TodoModel>>(jsonStr) ?? new List<TodoModel>();

            // Lägg till todo
            todos.Add(model);

            // Serialisera JSON
            jsonStr = JsonSerializer.Serialize(todos);
            // Ändra i todos.json
            System.IO.File.WriteAllText("todos.json", jsonStr);
            // Uppdatera session
            HttpContext.Session.SetString("Todos", jsonStr);

            // Rensa formulär
            ModelState.Clear();

            // Redirect till todos
            return RedirectToAction("Todos", "Home");
        }
        return View();
    }


    [HttpPost]
    public IActionResult UpdateStatus(string title, string description, string status)
    {
        // Läs in todos från session
        string jsonStr = HttpContext.Session.GetString("Todos") ?? "[]";
        var todos = JsonSerializer.Deserialize<List<TodoModel>>(jsonStr) ?? new List<TodoModel>();

        // Uppdatera todo status
        var todoToUpdate = todos.FirstOrDefault(t => t.Title == title && t.Description == description);
        if (todoToUpdate != null)
        {
            todoToUpdate.Status = status;

            // Serialisera JSON
            jsonStr = JsonSerializer.Serialize(todos);
            // Ändra i todos.json
            System.IO.File.WriteAllText("todos.json", jsonStr);
            // Uppdatera session
            HttpContext.Session.SetString("Todos", jsonStr);
        }

        // Redirect till todos
        return RedirectToAction("Todos");
    }


}

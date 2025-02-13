using Microsoft.AspNetCore.Mvc;
using dotnetTodo.Models;
using System.Text.Json;

namespace dotnetTodo.Controllers;

//Home Controller
public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Todos()
    {
        //Läs in todos
        string jsonStr = System.IO.File.ReadAllText("todos.json");
        //Deserialisera JSON
        var todos = JsonSerializer.Deserialize<List<TodoModel>>(jsonStr);

        //Returnera vy
        return View(todos);
    }

    public IActionResult AddTodo()
    {
        return View();
    }

    [HttpPost] //Controller för post-anrop
    public IActionResult AddTodo(TodoModel model)
    {
        if (ModelState.IsValid)
        {
            //Läs in todos
            string jsonStr = System.IO.File.ReadAllText("todos.json");
            //Deserialisera JSON
            var todos = JsonSerializer.Deserialize<List<TodoModel>>(jsonStr);

            //Lägg till todo
            if (todos != null)
            {
                todos.Add(model);

                //Serialisera JSON
                jsonStr = JsonSerializer.Serialize(todos);
                //Ändra i todos.json
                System.IO.File.WriteAllText("todos.json", jsonStr);
            }
            //Rensa formulär
            ModelState.Clear();

            //Redirect till todos
            return RedirectToAction("Todos", "Home");
        }
        return View();
    }

    [HttpPost]
    public IActionResult UpdateStatus(string Title, string Description, string Status)
    {
        //Läs in todos
        string jsonStr = System.IO.File.ReadAllText("todos.json");
        //Deserialisera JSON
        var todos = JsonSerializer.Deserialize<List<TodoModel>>(jsonStr);

        //Uppdatera todo status
        if (todos != null)
        {
            var todoToUpdate = todos.FirstOrDefault(t => t.Title == Title && t.Description == Description);
            if (todoToUpdate != null)
            {
                todoToUpdate.Status = Status;

                //Serialisera JSON
                jsonStr = JsonSerializer.Serialize(todos);
                //Ändra i todos.json
                System.IO.File.WriteAllText("todos.json", jsonStr);
            }
        }

        //Redirect till todos
        return RedirectToAction("Todos");
    }

}

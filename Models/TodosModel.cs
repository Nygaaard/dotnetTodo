namespace dotnetTodo.Models;

public class TodoModel
{
    //Properties
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required string Status { get; set; }
}
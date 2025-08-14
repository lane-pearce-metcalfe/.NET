using Microsoft.AspNetCore.Mvc;
using BlazorFullstackApp.Shared;

namespace BlazorFullstackApp.Server.Controllers;

// Declaring this class as an API controller
[ApiController]
[Route("api/todo")]

public class TodoController : ControllerBase
{
  // Creating a static list to store todo items in memory
  // Later I will translate this over to a database but I want to make sure everythings working right before moving onto that
  private static readonly List<TodoItem> todos =
  [
    new TodoItem { Id = 1, Title = "Test Title One", IsDone = false},
    new TodoItem { Id = 2, Title = "Test Title Two", IsDone = false}
  ];

  // Basic GET endpoint which just returns all of the todos
  [HttpGet]
  public ActionResult<List<TodoItem>> GetTodos() => todos;

  // Basic POST endpoint
  [HttpPost]
  public ActionResult<TodoItem> AddTodo(TodoItem todo)
  {
    // In a real database the +1 will be handled automatically
    todo.Id = todos.Count + 1;
    todos.Add(todo);
    // Returning the todo back to the client to confirm the todo has been created
    return todo;
  }
}
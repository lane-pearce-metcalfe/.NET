using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.Core.Services;

namespace ToDoApp.API.Controllers {
  [ApiController] // This is like saying "This is an API controller"
  [Route("api/todo")] // Base URL for api
  public class ToDoController : ControllerBase
  {
    private readonly ToDoService _todoService;

    public ToDoController(ToDoService todoService) {
      _todoService = todoService;
    }

    [HttpPost]
    public async Task<IActionResult> AddToDo([FromBody] AddToDoDto dto) // dto will hold request from JSON body
    {
      var newItem = await _todoService.AddToDoAsync(dto.Title, dto.Description);
      return Ok(); // Should probably be returning something more useful or descriptive but I can work on that later
    }
  }
  
  // Data object for creating an item
  public class AddToDoDto
  {
    [Required] // Title MUST be provided otherwise will return a 400 bad request
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
  }
}
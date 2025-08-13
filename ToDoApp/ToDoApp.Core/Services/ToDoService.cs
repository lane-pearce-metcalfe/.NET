using ToDoApp.Core.Models;
using ToDoApp.Core.Interfaces;

namespace ToDoApp.Core.Services
{
  public class ToDoService(IToDorepository repo)
  {
    private readonly IToDorepository _repo = repo;

    public async Task<ToDoItem> AddToDoAsync(string title, string description)
    {
      if (string.IsNullOrWhiteSpace(title))
        throw new ArgumentException("Title cannot be empty");

      var todo = new ToDoItem
      {
        Title = title,
        IsCompleted = false,
        Description = description,
      };

      return await _repo.AddAsync(todo);
    }
  }
}
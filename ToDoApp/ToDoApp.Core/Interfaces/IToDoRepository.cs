using ToDoApp.Core.Models;

namespace ToDoApp.Core.Interfaces
{
  public interface IToDorepository
  {
    Task<ToDoItem> AddAsync(ToDoItem item);
  }
}
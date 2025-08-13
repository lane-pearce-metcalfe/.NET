using Microsoft.EntityFrameworkCore;
using ToDoApp.Core.Interfaces;
using ToDoApp.Core.Models;
using ToDoApp.Infrastructure.Data;

namespace ToDoApp.Infrastructure.Repositories
{
  public class ToDoRepository : IToDorepository
  {
    private readonly AppDbContext _context;

    public ToDoRepository(AppDbContext context)
    {
      _context = context;
    }

    public async Task<ToDoItem> AddAsync(ToDoItem item)
    {
      _context.ToDoItems.Add(item);
      await _context.SaveChangesAsync();
      return item;
    }
  }
}

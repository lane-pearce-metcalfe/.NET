// Almost like in web development this is like "import board from ./board"
using Microsoft.EntityFrameworkCore;
using ToDoApp.Infrastructure.Data;
using ToDoApp.Infrastructure.Repositories;
using ToDoApp.Core.Interfaces;
using ToDoApp.Core.Services;

// Like creating a new web application
var builder = WebApplication.CreateBuilder(args);

// Database connection setup, bassicly telling the app how to connect to the SQL server database to store todo items
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Dependency injection setup, this is like telling the app that when someone asks for these services, give them these specific implementations
// Almost like connecting the dots between interfaces and their actual working code
builder.Services.AddScoped<IToDorepository, ToDoRepository>();
builder.Services.AddScoped<ToDoService>();

// Adding suport for API controllers like the classes that handle web requests
builder.Services.AddControllers();

// This allows our frontend that will be running on localhost:3000 to talk to the backends API
builder.Services.AddCors(options =>
{
  options.AddPolicy("AllowFrontend", policy => policy.WithOrigins("http://localhost:3000").AllowAnyHeader().AllowAnyMethod());
  // Allows request from localhost:3000, any HTTP headers, and any method such as GET POST PUT DELETE etc.
});

// Finnally taking all the services we've configured and putting it all together to build the web application
var app = builder.Build();

// Enableing CORS
app.UseCors("AllowFrontend");

//Mapping our controller endpoints so the app knows how to route requests like /api/todos/1 goes to the ToDoController
app.MapControllers();

// Actually starting to run the application
app.Run();
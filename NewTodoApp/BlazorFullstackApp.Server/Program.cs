// Creates a new web application builder and sets up the foundation for the web API
var builder = WebApplication.CreateBuilder(args);

// This allows the creation of API endpoints using controller classes
builder.Services.AddControllers();

// Adding CORS which allows the API to be called from web pages on different domains
builder.Services.AddCors(options =>
{
  // Creating a policy under "AllowBlazor"
  options.AddPolicy("AllowBlazor",
    // Only allowing requests from the Blazor app URL (https://localhost:7014)
    policy => policy.WithOrigins("https://localhost:7014").AllowAnyHeader().AllowAnyMethod()
    );
});

// Adding API documention services
// Mainly adding this because I saw other sources using it and thought it might come in handy later if I get stuck
builder.Services.AddEndpointsApiExplorer(); // Generates API documentation
builder.Services.AddSwaggerGen(); // Allows said API documention to be interactable

// Finally getting all the peices and putting them together to build the app
var app = builder.Build();

// This is just so the swagger UI only shows up during devlopment
// Whiuch this project will probably only be in devlopment so wont matter but thought I might as well add it
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

// Redirects all HTTP requests to HTTPS
app.UseHttpsRedirection();

// Enabling the CORS policy that was defined earlier
app.UseCors("AllowBlazor");
app.UseAuthorization();
// This connects URLs to controller methods
app.MapControllers();
// Finally starting the web server
app.Run();
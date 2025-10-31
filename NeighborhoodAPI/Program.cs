using Microsoft.EntityFrameworkCore;
using NeighborhoodAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure EF Core (using SQLite for now)
builder.Services.AddDbContext<NeighborhoodDbContext>(options =>
    options.UseSqlite("Data Source=neighborhoods.db"));

var app = builder.Build();

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// Ensure database file is created
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<NeighborhoodDbContext>();
    db.Database.EnsureCreated();
}

app.Run();

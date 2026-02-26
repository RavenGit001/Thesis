using Microsoft.EntityFrameworkCore;
using Thesis.Data;
using Thesis.Hubs;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// -----------------------------
// Controllers + JSON options
// -----------------------------
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.DefaultIgnoreCondition =
            System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault;
    });

// -----------------------------
// PostgreSQL DbContext (Railway Safe)
// -----------------------------
// Read DefaultConnection from environment variable first, fallback to appsettings.json
var defaultConnection = Environment.GetEnvironmentVariable("ConnectionStrings__DefaultConnection")
                        ?? builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<BreadDbContext>(options =>
{
    options.UseNpgsql(defaultConnection);
});

// -----------------------------
// SignalR
// -----------------------------
builder.Services.AddSignalR();

// -----------------------------
// Scalar / OpenAPI
// -----------------------------
builder.Services.AddOpenApi();

// -----------------------------
// CORS (for MAUI client)
/// -----------------------------
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// -----------------------------
// Build App
// -----------------------------
var app = builder.Build();

// -----------------------------
// Auto Apply EF Migrations
// -----------------------------
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<BreadDbContext>();
    try
    {
        db.Database.Migrate();
        Console.WriteLine("Database migration applied successfully.");
    }
    catch (Exception ex)
    {
        Console.WriteLine("Database migration failed: " + ex.Message);
        throw; // Stops app if DB cannot connect
    }
}

// -----------------------------
// HTTP Request Pipeline
// -----------------------------
if (app.Environment.IsDevelopment())
{
    app.MapScalarApiReference();
    app.MapOpenApi();
}

app.UseCors();
app.UseHttpsRedirection();
app.UseAuthorization();

// Controllers
app.MapControllers();

// SignalR Hub
app.MapHub<AlertHub>("/alerthub");

// Run App
app.Run();
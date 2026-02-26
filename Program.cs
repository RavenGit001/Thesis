using Microsoft.EntityFrameworkCore;
using Thesis.Data;
using Thesis.Hubs;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// -----------------------------
// Services
// -----------------------------

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.DefaultIgnoreCondition =
            System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault;
    });

// PostgreSQL DbContext
builder.Services.AddDbContext<BreadDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// SignalR
builder.Services.AddSignalR();

// Scalar / OpenAPI
builder.Services.AddOpenApi();

// CORS (allow from anywhere for testing)
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
// Auto-apply EF Migrations (Railway Friendly)
// -----------------------------
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<BreadDbContext>();
    try
    {
        db.Database.Migrate(); // Creates tables if they don't exist
        Console.WriteLine("Database migration applied successfully.");
    }
    catch (Exception ex)
    {
        Console.WriteLine("Database migration failed: " + ex.Message);
        throw;
    }
}

// -----------------------------
// HTTP Pipeline
// -----------------------------
if (app.Environment.IsDevelopment())
{
    app.MapScalarApiReference();
    app.MapOpenApi();
}

app.UseCors();
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();
app.MapHub<AlertHub>("/alerthub");

app.Run();
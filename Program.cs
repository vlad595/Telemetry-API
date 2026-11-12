using Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();

builder.Services.AddCors(options =>
{
    options.AddPolicy("LocalWeb", policy => policy
        .WithOrigins("http://localhost:4200", "http://127.0.0.1:4200")
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials());
});

var app = builder.Build();

app.UseCors("LocalWeb");

app.MapHub<MainHub>("/mainhub");

app.MapGet("/", () => "Hub works!");

app.Run();

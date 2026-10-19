using Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowAllPolicy", policy => { policy.AllowAnyHeader(); policy.AllowAnyOrigin(); policy.AllowAnyMethod(); });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseCors("AllowAllPolicy");
}

app.MapHub<MainHub>("/mainhub");

app.MapGet("/", () => "Hello World!");

app.Run();

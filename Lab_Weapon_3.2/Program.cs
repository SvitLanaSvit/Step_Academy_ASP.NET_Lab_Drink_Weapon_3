using Lab_Weapon_3._2;
using Lab_Weapon_3._2.Middleware;
using System.Threading;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<Warrior>();
builder.Services.AddTransient<IWeapon, Bazuka>();
builder.Services.AddTransient<IWeapon, Sword>();
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

//not important, may be used or not used
app.Map("/warrior", context =>
{
    context.UseMyMiddleware();
});

app.Run(async context =>
{
    Warrior? warrior = app.Services.GetService<Warrior>();
    context.Response.ContentType = "text/html; charset=utf-8";
    await context.Response.WriteAsync($"<h2>{warrior?.GetWeaponMessage()}</h2>");
});

app.Run();
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

app.UseMiddleware<WeaponMiddleware>();

app.Run();
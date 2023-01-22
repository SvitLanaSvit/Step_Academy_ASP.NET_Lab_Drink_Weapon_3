using Lab_Drink_3;
using Lab_Drink_3.Middleware;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<DrinkService>();
builder.Services.AddTransient<AllDrinkService>();

builder.Services.AddTransient<IDrink, Tee>();
builder.Services.AddTransient<IDrink, Caffe>();
builder.Services.AddTransient<IDrink, Juice>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Map("/drink", (contex) =>
{
    contex.UseMiddleware<DrinkMiddleware>(); 
});

app.Map("/allDrink", (contex) =>
{
    contex.UseMiddleware<AllDrinkMiddleware>(); 
});

app.Run();

using Lab_Drink_Weapon_3;
using Lab_Drink_Weapon_3.Middleware;

var builder = WebApplication.CreateBuilder(args);
//---------------------task_1----------------------
builder.Services.AddTransient<DrinkService>();
builder.Services.AddTransient<IDrink, Tee>();
//---------------------task_2----------------------
builder.Services.AddTransient<AllDrinkService>();
builder.Services.AddTransient<IDrink, Tee>();
builder.Services.AddTransient<IDrink, Caffe>();
builder.Services.AddTransient<IDrink, Juice>();
//--------------------------------------------
var app = builder.Build();

app.Map("/drink", (contex) =>
{
    contex.UseMiddleware<DrinkMiddleware>(); //map chooses last of builder.Services.AddTransient
});

app.Map("/allDrink", (contex) =>
{
    contex.UseMiddleware<AllDrinkMiddleware>(); //map chooses last of builder.Services.AddTransient
});

//---------------------------------------------------------------------
//for task_1
//app.Run(async context =>
//{
//    DrinkService? drinkService = app.Services.GetService<DrinkService>();
//    await context.Response.WriteAsync($"{drinkService?.GetDrinkMessage()}");
//});

//for task_2
app.Run(async context =>
{
    AllDrinkService? drinkServices = app.Services.GetService<AllDrinkService>();
    context.Response.ContentType = "text/html; charset=utf-8";
    await context.Response.WriteAsync($"{drinkServices?.GetDrinkMessage()}");
});
//----------------------------------------------------------------------

app.Run();
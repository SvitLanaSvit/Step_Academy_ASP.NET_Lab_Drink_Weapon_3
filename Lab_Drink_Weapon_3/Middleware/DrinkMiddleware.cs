namespace Lab_Drink_Weapon_3.Middleware
{
    public class DrinkMiddleware
    {
        public readonly DrinkService drinkService;

        public DrinkMiddleware(RequestDelegate _, DrinkService drinkService)
        {
            this.drinkService = drinkService;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            context.Response.ContentType = "text/html; charset=utf-8";
            await context.Response.WriteAsync($"<h2 style='color: navy'>Current drink: " +
                $"{drinkService.GetDrinkMessage()} Current time: {DateTime.Now.ToLongTimeString()}</h2>");
        }
    }
}
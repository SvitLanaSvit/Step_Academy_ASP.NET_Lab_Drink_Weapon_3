using System.Text;

namespace Lab_Drink_3.Middleware
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
            StringBuilder sb = new StringBuilder();
            context.Response.ContentType = "text/html; charset=utf-8";
            sb.AppendLine($"<h2 style='color: navy'>Current drink:</h2>");
            sb.AppendLine($"<h2 style='color: green'>{drinkService.GetDrinkMessage()}</h2>");
            sb.AppendLine($"<h2 style='color: navy'>Current time: {DateTime.Now.ToLongTimeString()}</h2>");
            await context.Response.WriteAsync(sb.ToString());
        }
    }
}
namespace Lab_Drink_3.Middleware
{
    public class AllDrinkMiddleware
    {
        public readonly AllDrinkService allDrinkService;
        public AllDrinkMiddleware(RequestDelegate _, AllDrinkService allDrinkService)
        {
            this.allDrinkService = allDrinkService;
        }

        public async Task InvokeAsync(HttpContext context) 
        {
            context.Response.ContentType = "text/html; charset=utf-8";
            await context.Response.WriteAsync($"<h2 style='color: navy'>Current drink: {allDrinkService.GetDrinkMessage()} Current time: {DateTime.Now.ToLongTimeString()}</h2>");
        }
    }
}
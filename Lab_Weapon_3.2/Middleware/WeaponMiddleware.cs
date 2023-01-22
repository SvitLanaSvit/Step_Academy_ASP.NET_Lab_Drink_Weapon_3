namespace Lab_Weapon_3._2.Middleware
{
    public class WeaponMiddleware
    {
        public readonly Warrior warrior;
        public WeaponMiddleware(RequestDelegate _, Warrior warrior)
        {
            this.warrior = warrior;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            context.Response.ContentType = "text/html; charset=utf-8";
            await context.Response.WriteAsync($"<h2>{warrior.GetWeaponMessage()}</h2>");
        }
    }
}

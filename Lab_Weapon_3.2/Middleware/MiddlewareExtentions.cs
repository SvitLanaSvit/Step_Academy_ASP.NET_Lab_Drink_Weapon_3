namespace Lab_Weapon_3._2.Middleware
{
    public static class MiddlewareExtentions
    {
        public static IApplicationBuilder UseMyMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<WeaponMiddlewareMap>();
        }
    }
}
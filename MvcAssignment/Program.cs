namespace MvcAssignment
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Hello1 \n");
                await next();
            });
            app.Map("/end", a => {
                a.Run(c => c.Response.WriteAsync("ended !! "));
            });
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Hello2 \n");
                await next();
            });

            //app.MapControllerRoute(
            //    name: "default",
            //    pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Map("/hello", x => x.Response.WriteAsync("Hello"));

            app.Run();

        }
    }
}

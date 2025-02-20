namespace Book_Management
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Добавяне на сесия
            builder.Services.AddDistributedMemoryCache(); // Необходим за сесията
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(1); // Сесията ще изтича след 1 минута
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });


            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Добави използването на сесия
            app.UseSession();

            app.UseRouting();
            app.UseAuthorization();
            app.MapControllers();
            app.MapDefaultControllerRoute();

            app.Run();

        }
    }
}

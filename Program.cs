namespace Book_Management
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // �������� �� �����
            builder.Services.AddDistributedMemoryCache(); // ��������� �� �������
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(1); // ������� �� ������ ���� 1 ������
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });


            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // ������ ������������ �� �����
            app.UseSession();

            app.UseRouting();
            app.UseAuthorization();
            app.MapControllers();
            app.MapDefaultControllerRoute();

            app.Run();

        }
    }
}

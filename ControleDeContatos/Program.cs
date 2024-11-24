using ControleDeContatos.Data;
using ControleDeContatos.Repository;
using Microsoft.EntityFrameworkCore;

namespace ControleDeContatos;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();
        builder.Services.AddRazorPages()
        .AddRazorRuntimeCompilation();

        builder.Services.AddControllersWithViews();
        builder.Services.AddDbContext<BancoContext>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase")));
        builder.Services.AddScoped<IContatoRepositorio, ContatoRepositorio>();
       
        var app = builder.Build();


        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
        }
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}

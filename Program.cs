using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MvcDay2Task.Migrations;
using MvcDay2Task.Models;
using MvcDay2Task.Repository;

namespace MvcDay2Task;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext<Context>(options =>
        {
            options.UseSqlServer("Data Source=.;Initial Catalog=MvcDay2Task;Integrated Security=True;Encrypt=False;Trust Server Certificate=True");
        });
        // Add services to the container.
        builder.Services.AddControllersWithViews();

        builder.Services.AddSession(Options =>
        {
            Options.IdleTimeout = TimeSpan.FromMinutes(20);
        });

        builder.Services.AddIdentity<ApplicationUser,IdentityRole>().AddEntityFrameworkStores<Context>();

        builder.Services.AddScoped<IInstructorRepository, InstructorRepository>();
        builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
        builder.Services.AddScoped<ICourseRepository, CourseRepository>();
        builder.Services.AddScoped<ITraineeRepository, TraineeRepository>();
        builder.Services.AddScoped<ITraineeCrsResultRepository, TraineeCrsResultRepository>();



        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseSession();

        app.UseRouting();

        app.UseAuthentication();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}

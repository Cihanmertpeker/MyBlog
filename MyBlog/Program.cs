using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileSystemGlobbing.Internal.Patterns;
using MyBlogMVC.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BlogDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Local"));
});


builder.Services.AddControllersWithViews();

var app = builder.Build();


app.UseStaticFiles();

app.UseRouting();

app.UseEndpoints(endpoints =>
{

    endpoints.MapAreaControllerRoute(name:"areaRoute",areaName:"Admin",pattern:"{Area}/{Controller=Category}/{Action=Index}/{id?}");

    endpoints.MapDefaultControllerRoute();

});

app.Run();

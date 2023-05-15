using Fallah_App.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession(opt =>
{
    opt.IdleTimeout = TimeSpan.FromDays(10);
}
    );
if (Environment.GetEnvironmentVariable("DB_NAME") != null)
{
    builder.Services.AddDbContext<MyContext>(opt =>
    {
        opt.UseSqlServer(builder.Configuration.GetConnectionString("MyContext"));
    });
    
}
else
{
    builder.Services.AddDbContext<MyContext>(opt =>
    {
        opt.UseSqlServer(builder.Configuration.GetConnectionString("localConnection"));
    });

}
//////////////////////////test tali /////////
/*else
{
    builder.Services.AddDbContext<MyContext>(opt =>
    {
        opt.UseSqlServer(builder.Configuration.GetConnectionString("adnaneConnection"));
    });

}*/



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
   
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseSession();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

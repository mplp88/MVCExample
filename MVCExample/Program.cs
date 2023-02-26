using Microsoft.EntityFrameworkCore;
using MVCExample.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<TodoListContext>(options =>
{
    //options.UseSqlServer(builder.Configuration.GetConnectionString("MVCExampleConnectionString"));
    string? connString = builder.Configuration.GetConnectionString("MVCExampleMySQLConnectionString");
    if(!string.IsNullOrEmpty(connString))
    {
        options.UseMySQL(connString);
    }
    else
    {
        throw new ArgumentNullException("Connection string cannot null");
    }
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if(!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

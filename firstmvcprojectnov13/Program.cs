using firstmvcprojectnov13.Data;
using firstmvcprojectnov13.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped< IEmployeeRepository,SqlEmployeeRepository>();  // dependency injection in EmployeeController.cs

builder.Services.AddScoped<AppDbContext, AppDbContext>();  // dependency injection for sql used in SqlEmployeeRepository.cs

builder.Services.AddDbContext<AppDbContext>(options =>                                                 // configuring AppDbContext.cs file as entry point for sql to our code
{ 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultSqlConnection"));
});                                                                                                  // configuring AppDbContext.cs file as entry point for sql to our code


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
    pattern: "{controller=Employee}/{action=Index}/{id?}");

app.Run();

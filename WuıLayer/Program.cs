
using EntityLayer.Abstract;
using BusinessLayer;
using DataLayer;
using DataLayer.Abstract;
using EntityLayer.Concreate;
using BusinessLayer.Concreate;
using DataLayer.Concreate;
using System.Net.Http.Headers;
using System.Text;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDataAccessServices(builder.Configuration);
builder.Services.AddBusinessServices();
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

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Giris}/{id?}");

app.Run();

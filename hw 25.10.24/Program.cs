using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using hw_25._10._24;
using hw_25._10._24.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<hw_25_10_24Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("hw_25_10_24Context") ?? throw new InvalidOperationException("Connection string 'hw_25_10_24Context' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

// DI
builder.Services.AddSingleton<IFileService, FileService>();

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
	pattern: "{controller=Workers}/{action=Index}/{id?}");

app.Run();

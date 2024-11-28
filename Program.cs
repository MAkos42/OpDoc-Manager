using Microsoft.EntityFrameworkCore;
using OpDoc_Manager.Data;
using OpDoc_Manager.Service;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

var cultureInfo = new CultureInfo("hu-HU");
CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.InvariantCulture;

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));
builder.Services.AddScoped<IForkliftModelsService, ForkliftModelsService>();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation().AddViewOptions(options => options.HtmlHelperOptions.ClientValidationEnabled = true); ;


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
    name: "ForkliftRoute",
    pattern: "{controller}/{id}/{action}",
    defaults: new { controller = "Forklift" }
    );

app.MapControllerRoute(
    name: "ModelRoute",
    pattern: "{controller}/{id}/{action}",
    defaults: new { controller = "Model" }
    );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/"
    );

app.Run();

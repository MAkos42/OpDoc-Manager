using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OpDoc_Manager.Data;
using OpDoc_Manager.Service;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

var cultureInfo = new CultureInfo("hu-HU");
CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.InvariantCulture;

// Szerverkapcsolat l�trehoz�sa
var connectionString = builder.Configuration["ConnectionStrings:OpDocConnection"] ?? throw new InvalidOperationException("Connection string not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));

//Service kiszolg�l�k regisztr�l�sa
builder.Services.AddScoped<IForkliftModelsService, ForkliftModelsService>();
builder.Services.AddScoped<IForkliftIndexService, ForkliftIndexService>();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

//Felhaszn�l�keezel� be�ll�t�sa
builder.Services.AddDefaultIdentity<OpDocUser>(options =>
{
    options.User.RequireUniqueEmail = true;
    options.Password.RequiredLength = 8;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.SignIn.RequireConfirmedEmail = true;
    options.SignIn.RequireConfirmedPhoneNumber = false;
    options.SignIn.RequireConfirmedAccount = true;
}).AddRoles<IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();

//Kliens oldal� �rt�k-ellen�rz�s aktiv�l�sa
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation().AddViewOptions(options => options.HtmlHelperOptions.ClientValidationEnabled = true); ;

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

//�tvonalak regisztr�l�sa
app.MapControllerRoute(
    name: "ForkliftRoute",
    pattern: "{controller}/{id}/{action}",
    defaults: new { controller = "Forklift" }
    ).WithStaticAssets();

app.MapControllerRoute(
    name: "ModelRoute",
    pattern: "{controller}/{id}/{action}",
    defaults: new { controller = "Model" }
    ).WithStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
).WithStaticAssets();

app.MapRazorPages().WithStaticAssets();

//Admin felhaszn�l� gener�l�sa
using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<OpDocUser>>();

    string[] roleNames = { "Admin", "Technician", "Operator" };
    foreach (var roleName in roleNames)
    {
        var roleExist = await roleManager.RoleExistsAsync(roleName);
        if (!roleExist)
        {
            await roleManager.CreateAsync(new IdentityRole(roleName));
        }
    }

    var adminUser = new OpDocUser
    {
        UserName = "admin@opdoc.com",
        Email = "admin@opdoc.com",
        EmailConfirmed = true,
        FirstName = "�kos",
        LastName = "M�sz�ros"
    };

    string adminPassword = "Admin123!";
    var user = await userManager.FindByEmailAsync(adminUser.Email);

    if (user == null)
    {
        var createAdminUser = await userManager.CreateAsync(adminUser, adminPassword);
        if (createAdminUser.Succeeded)
        {
            await userManager.AddToRoleAsync(adminUser, "Admin");
            await userManager.AddToRoleAsync(adminUser, "Technician");
            await userManager.AddToRoleAsync(adminUser, "Operator");
        }
    }
}


app.Run();
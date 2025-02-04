using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SoFetchGrooming.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

// Register the database context with the connection string from the configuration
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// Add a developer exception page for development environments
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Add default identity and entity framework stores
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

// Add controllers with views
builder.Services.AddControllersWithViews();

// Build the application
var app = builder.Build();

// Create a scope to get services
using (var scope = app.Services.CreateScope())
{
    // Get instance of RoleManager and UserManager from the service provider
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

    // Check if the 'Admin' role exists, if not create it
    if (await roleManager.FindByNameAsync("Admin") == null)
    {
        await roleManager.CreateAsync(new IdentityRole("Admin"));
    }

    // Check if the admin user exists, if not create it
    var adminUser = await userManager.FindByEmailAsync(builder.Configuration["AdminUser:Email"]);
    if (adminUser == null)
    {
        adminUser = new IdentityUser
        {
            UserName = builder.Configuration["AdminUser:Email"],
            Email = builder.Configuration["AdminUser:Email"],
            EmailConfirmed = true // Set EmailConfirmed to true
        };
        await userManager.CreateAsync(adminUser, builder.Configuration["AdminUser:Password"]);
        await userManager.AddToRoleAsync(adminUser, "Admin");
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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
app.MapRazorPages();

app.Run();

using ASP.net_FAQQs_APP.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Add this middleware to redirect to lowercase URLs
app.Use(async (context, next) =>
{
    var request = context.Request;
    if (request.Path.HasValue && request.Path.Value.Any(char.IsUpper))
    {
        var lowerCaseUrl = request.Path.Value.ToLowerInvariant();
        context.Response.Redirect(lowerCaseUrl + request.QueryString, true);
        return;
    }
    await next();
});

app.UseEndpoints(endpoints =>
{
    // Default route: Directly handles URLs without "home/index"
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{action=index}/{id?}",
        defaults: new { controller = "home" });

    // Custom route for filtering by topic
    endpoints.MapControllerRoute(
        name: "filterByTopic",
        pattern: "topic/{topic}",
        defaults: new { controller = "home", action = "filterbytopic" });

    // Custom route for filtering by category
    endpoints.MapControllerRoute(
        name: "filterByCategory",
        pattern: "category/{category}",
        defaults: new { controller = "home", action = "filterbycategory" });

    // Custom route for filtering by both topic and category
    endpoints.MapControllerRoute(
        name: "filterByTopicAndCategory",
        pattern: "topic/{topic}/category/{category}",
        defaults: new { controller = "home", action = "filterbytopicandcategory" });
});


app.MapRazorPages();

app.Run();

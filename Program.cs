
var builder = WebApplication.CreateBuilder(args);

// Aktivera MVC
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Aktivera statiska filer
app.UseStaticFiles();

// Aktivera routing
app.UseRouting();

// Routing
app.MapControllerRoute(
    name: "default",
    pattern: "{Controller=Home}/{Action=Index}/{id?}");

app.Run();

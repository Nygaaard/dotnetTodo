var builder = WebApplication.CreateBuilder(args);

// Aktivera MVC och runtime-kompilering
builder.Services.AddControllersWithViews()
    .AddRazorRuntimeCompilation();

// Lägg till sessionshantering
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Aktivera statiska filer
app.UseStaticFiles();

// Aktivera routing
app.UseRouting();

// Aktivera session
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{Controller=Home}/{Action=Index}/{id?}");

app.Run();

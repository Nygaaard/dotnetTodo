var builder = WebApplication.CreateBuilder(args);

// Aktivera MVC och runtime-kompilering
builder.Services.AddControllersWithViews()
    .AddRazorRuntimeCompilation();

var app = builder.Build();

// Aktivera statiska filer
app.UseStaticFiles();

// Aktivera routing
app.UseRouting();

// Aktivera Endpoints
app.UseEndpoints(endpoints =>
{
    _ = endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();

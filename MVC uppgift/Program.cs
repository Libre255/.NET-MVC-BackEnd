var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseSession();
app.MapControllerRoute(name: "default", pattern: "{action}", defaults: new { controller = "Home", action = "Index" });
app.MapControllerRoute(name: "Doctor", pattern: "FeverCheck", defaults: new { controller = "Doctor", action = "FeverCheck"});
app.MapControllerRoute(name: "Game", pattern: "GuessingGame", defaults: new { controller = "Game", action = "GuessingGame" });

app.Run();
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
//if the defaults is index and you want to access another page in that controller you will have to use {action}
app.MapControllerRoute(name: "default", pattern: "{action}", defaults: new { controller = "Home", action = "Index" });
app.MapControllerRoute(name: "Doctor", pattern: "FeverCheck", defaults: new { controller = "Doctor", action = "FeverCheck"});

app.Run();
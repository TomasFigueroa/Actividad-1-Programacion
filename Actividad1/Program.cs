using Actividad1;


var builder = WebApplication.CreateBuilder(args);

// Servicio para mantener el contador de usuarios
builder.Services.AddSingleton<UserCounter>();

builder.Services.AddRazorPages();
builder.Services.AddSession();

var app = builder.Build();

app.UseSession();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();

using BibliotecaAppG1.Data;
using BibliotecaAppG1.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Agrega el contexto de base de datos usando SQLite
builder.Services.AddDbContext<BibliotecaContext>(options => options.UseSqlite("Data Source=biblioteca.db"));

builder.Services.AddScoped<LibroRepositorio>();
builder.Services.AddScoped<AutorRepositorio>();
builder.Services.AddScoped<LibroServicio>();
builder.Services.AddScoped<AutorServicio>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Libros}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();

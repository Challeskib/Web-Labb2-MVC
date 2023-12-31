using Web_Labb1_MVC.Models;
using Web_Labb1_MVC.Services;
using Web_Labb1_MVC.Services.ServiceInterfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient<IBookService, BookService>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddHttpClient<IAuthorService, AuthorService>();
builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddHttpClient<IGenreService, GenreService>();
builder.Services.AddScoped<IGenreService, GenreService>();

StaticDetails.BookApiBase = builder.Configuration["ServiceUrls:SUT22BookAPI"];

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
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

app.Run();

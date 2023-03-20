using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MovieCatalogue.BLL.Implementations;
using MovieCatalogue.BLL.Interfaces;
using MovieCatalogue.DAL.Entities;
using MovieCatalogue.DAL.Repository;
using System.Reflection;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<MovieCatalogueDbContext>(opts =>
{
    // this will only work if there's a section called ConnectionStrings on the appSettings
    // var defaultConn = builder.Configuration.GetConnectionString("DefaultConn");

    var defaultConn = builder.Configuration.GetSection("ConnectionString")["DefaultConn"];

    opts.UseSqlServer(defaultConn, x => x.MigrationsAssembly("MovieCatalogue.DAL")
    );

});

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<MovieCatalogueDbContext>()
    .AddDefaultTokenProviders();

//builder.Services.ConfigureApplicationCookie(options => options.LoginPath = "/UserAuthentication/Login");
builder.Services.AddScoped<IUserAuthenticationService, UserAuthenticationService>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork<MovieCatalogueDbContext>>();
builder.Services.AddScoped<IMovieService, MovieService>();//todo: show other life-cycles

builder.Services.AddAutoMapper(Assembly.Load("MovieCatalogue.BLL"));


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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


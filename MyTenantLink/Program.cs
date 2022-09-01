using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using MyTenantLink.Data;
using MyTenantLink.Services;
using MyTenantLink.Services.Repo;
using MyTenantLink.Services.Repo.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>((DbContextOptionsBuilder options) =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddDefaultIdentity<User>((IdentityOptions options) => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<MyTenantLink.Data.AppDbContext>();
builder.Services.AddRazorPages();
builder.Services.AddSingleton<IEmailSender, EmailSender>();

//In Progress Email Sender Feature
//builder.Services.AddSingleton<ISmsSender, SmsSender>();


builder.Services.AddScoped<IRepo, Repo>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();

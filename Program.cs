using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Konya_Zoltan_Proiect_Managementul_Concediilor.Data;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/Cereri");
    options.Conventions.AuthorizeFolder("/Departamente");
    options.Conventions.AuthorizeFolder("/Functii");
    options.Conventions.AuthorizeFolder("/Angajati");
    options.Conventions.AuthorizeFolder("/Categorii");
    options.Conventions.AuthorizeFolder("/Stari");
});

builder.Services.AddDbContext<Konya_Zoltan_Proiect_Managementul_ConcediilorContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Konya_Zoltan_Proiect_Managementul_ConcediilorContext") ?? throw new InvalidOperationException("Connection string 'Konya_Zoltan_Proiect_Managementul_ConcediilorContext' not found.")));

builder.Services.AddDbContext<LibraryIdentityContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Konya_Zoltan_Proiect_Managementul_ConcediilorContext") ?? throw new InvalidOperationException("Connection string 'Konya_Zoltan_Proiect_Managementul_ConcediilorContext' not found.")));

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
     options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<LibraryIdentityContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapRazorPages();

app.Run();

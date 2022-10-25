using Microsoft.EntityFrameworkCore;
using ReservationCore.Models;
using ReservationCore.Models.ReservationsRepos;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IResevationRepository, ReservationReposistory>();

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<HotelReservationContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("AppCore")));
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

app.UseAuthorization();

app.MapRazorPages();

app.Run();

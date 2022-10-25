using Microsoft.EntityFrameworkCore;
using ReservationCore.Models;
using ReservationCore.Repositories.MealsRepo;
using ReservationCore.Repositories.RoomRepo;
using ReservationCore.Repositories.Seasons;
using ReservationCore.ReservationsRepos;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IResevationRepository, ReservationReposistory>();
builder.Services.AddScoped<IMealsRepository, MealsRepository>();
builder.Services.AddScoped<IRoomTypeRepository, RoomTypeRepository>();
builder.Services.AddScoped<ISeasonRepository, SeasonRepository>();

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

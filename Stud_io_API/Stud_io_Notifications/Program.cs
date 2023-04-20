using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Stud_io_Notifications.Configurations;
using Stud_io_Notifications.Services.Implementations;
using Stud_io_Notifications.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<NotificationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString"));
});

builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddCors(opt => {
    opt.AddPolicy("CorsPolicy", policy => {
        policy.AllowAnyMethod().AllowCredentials().AllowAnyHeader().WithOrigins("http://localhost:3000");
    });
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IAnnouncementService, AnnouncementService>();
builder.Services.AddScoped<IDeadlineService, DeadlineService>();
builder.Services.AddScoped<IInformationService, InformationService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();

using Microsoft.EntityFrameworkCore;
using Stripe;
using Stud_io.Payment.Services.Implementation;
using Stud_io.Payment.Services.Interfaces;
using Stud_io_Payment.Configurations;
using Stud_io_Payment.Services.Implementation;
using Stud_io_Payment.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<PaymentDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddCors(opt => {
    opt.AddPolicy("CorsPolicy", policy => {
        policy.AllowAnyMethod().AllowCredentials().AllowAnyHeader().WithOrigins("http://localhost:5173");
    });
});

StripeConfiguration.ApiKey = builder.Configuration["StripeSettings:SecretKey"];

builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddScoped<IHistoryService, HistoryService>();
builder.Services.AddScoped<ITypeOfPaymentService, TypeOfPaymentService>();
builder.Services.AddScoped<PaymentService>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
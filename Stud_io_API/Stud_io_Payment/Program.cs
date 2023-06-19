using Microsoft.EntityFrameworkCore;
using Payment;
using Payment.Application;
using Payment.Contracts;
using Stud_io.Payment.Services.Implementation;
using Stud_io.Payment.Services.Implementations;
using Stud_io.Payment.Services.Interfaces;
using Stud_io_Payment.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<PaymentDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddCors(opt => {
    opt.AddPolicy("CorsPolicy", policy => {
        policy.AllowAnyMethod().AllowCredentials().AllowAnyHeader().WithOrigins(builder.Configuration["CorsOriginsEndpoint:ReactOrigin"]);
    });
});

builder.Services.AddStripeInfrastructure(builder.Configuration);

builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddScoped<ITypeOfPaymentService, TypeOfPaymentService>();
builder.Services.AddScoped<IStripeAppService, StripeAppService>();
builder.Services.AddScoped<IMailKitEmailService, MailKitEmailService>();

// Register IHttpClientFactory
builder.Services.AddHttpClient();

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
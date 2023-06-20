using Microsoft.EntityFrameworkCore;
using Stud_io.Dormitory.Services.Implementations;
using Stud_io.Dormitory.Services.Interfaces;
using Stud_io_Dormitory.Configurations;
using Stud_io_Dormitory.Services.Implementations;
using Stud_io_Dormitory.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DormitoryDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString"));
});

builder.Services.AddCors(opt => {
    opt.AddPolicy("CorsPolicy", policy => {
        policy.AllowAnyMethod().AllowCredentials().AllowAnyHeader().WithOrigins(builder.Configuration["CorsOriginsEndpoint:ReactOrigin"]);
    });
});

builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddScoped<IDormitoryService, DormitoryService>();
builder.Services.AddScoped<IRoomService, RoomService>();
builder.Services.AddScoped<IQuestionnaireService, QuestionnaireService>();
builder.Services.AddScoped<DormitoryDataGenerator>();

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

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<DormitoryDbContext>();
    var dormitoryService = scope.ServiceProvider.GetRequiredService<IDormitoryService>();
    dbContext.Database.EnsureCreated();

    var dormitoryDataGenerator = scope.ServiceProvider.GetRequiredService<DormitoryDataGenerator>();
    dormitoryDataGenerator.GenerateRoomsForDormitories();
}

app.Run();

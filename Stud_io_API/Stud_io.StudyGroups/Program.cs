using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Stud_io.Configuration;
using Stud_io.Extensions;
using Stud_io.StudyGroups.Controllers;
using Stud_io.StudyGroups.Interfaces;
using Stud_io.StudyGroups.Models;
using Stud_io.StudyGroups.Services;
using Stud_io.StudyGroups.Services.Implementation;
using Stud_io.StudyGroups.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddControllers(opt =>
//{
//    // Cdo Endpoint kerkon authentication, pervec atyre qe ia shtojme [AllowAnonnymous]
//    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
//    opt.Filters.Add(new Microsoft.AspNetCore.Mvc.Authorization.AuthorizeFilter(policy));
//});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//builder.Services.AddCors();
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", policy =>
    {
        policy.AllowAnyMethod().AllowCredentials().AllowAnyHeader().WithOrigins("http://localhost:5173");
    });
});

builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

//builder.Services.AddDefaultIdentity<AppUser>().AddRoles<IdentityRole>()
//    .AddEntityFrameworkStores<ApplicationDbContext>();
//builder.Services.AddIdentityServices(builder.Configuration);
//builder.Services.AddScoped<IUserService, UserService>();
//builder.Services.AddScoped<AccountController>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<IStudyGroupService, StudyGroupService>();
builder.Services.AddScoped<IFacultyService, FacultyService>();
builder.Services.AddScoped<IMajorService, MajorService>();

// Register IHttpClientFactory
builder.Services.AddHttpClient();


var app = builder.Build();

//var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();

//using (var scope = scopeFactory.CreateScope())
//{
//    var services = scope.ServiceProvider;
//    try
//    {
//        var context = services.GetRequiredService<ApplicationDbContext>();
//        var userManager = services.GetRequiredService<UserManager<AppUser>>();
//        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
//        await context.Database.MigrateAsync();
//        await Seed.SeedData(context, userManager, roleManager);
//    }
//    catch (Exception ex)
//    {
//        var logger = services.GetRequiredService<ILogger<Program>>();
//        logger.LogError(ex, "An error occured during migration");
//    }
//}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("CorsPolicy");

//app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:5173"));

//app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

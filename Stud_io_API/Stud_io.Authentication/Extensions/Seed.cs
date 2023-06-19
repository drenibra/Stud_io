using Microsoft.AspNetCore.Identity;
using Stud_io.Configuration;
using Stud_io.Authentication.Models;

namespace Stud_io.Extensions
{
    public class Seed
    {
        public static async Task SeedData(ApplicationDbContext context,
            UserManager<AppUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            /*if (!roleManager.RoleExistsAsync("Director").Result)
            {
                await roleManager.CreateAsync(new IdentityRole("Director"));
            }

            if (!roleManager.RoleExistsAsync("Recruiter").Result)
            {
                await roleManager.CreateAsync(new IdentityRole("Recruiter"));
            }*/

            if (!roleManager.RoleExistsAsync("Admin").Result)
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }

            if (!roleManager.RoleExistsAsync("Student").Result)
            {
                await roleManager.CreateAsync(new IdentityRole("Student"));
            }

            if (!userManager.Users.Any())
            {
                var users = new List<AppUser>
                {
                    new AppUser{FirstName = "Dren", LastName = "Ibrahimi", UserName="dreni", Email = "di53843@ubt-uni.net"},
                    new AppUser{FirstName = "Fat", LastName = "Sijarina", UserName="fati", Email = "fs51701@ubt-uni.net"},
                    new AppUser{FirstName = "Bleona", LastName = "Gerbavci", UserName="bleona", Email = "bg52732@ubt-uni.net"},
                    new AppUser{FirstName = "Alma", LastName = "Novoberdaliu", UserName="alma", Email = "an51718@ubt-uni.net"},
                    new AppUser{FirstName = "Rrezart", LastName = "Hetemi", UserName="rrezi", Email = "rh52741@ubt-uni.net"},
                };


                foreach (var user in users)
                {
                    await userManager.CreateAsync(user, "Pa$$w0rd");
                    await userManager.AddToRoleAsync(user, "Student");
                }
            }
        }
    }
}

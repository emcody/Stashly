using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUsersAsync(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new AppUser
                {
                    DisplayName = "Adam",
                    Email = "adam@test.com",
                    UserName = "adam@test.com"
                };

                await userManager.CreateAsync(user, "Pa$$w0rd");
            }
        }
    }
}
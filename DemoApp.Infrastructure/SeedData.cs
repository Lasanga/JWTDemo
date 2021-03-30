using DemoApp.Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace DemoApp.Infrastructure
{
    public class SeedData
    {
        public static void EnsureSeedData(string connectionString)
        {
            var services = new ServiceCollection();
            services.AddLogging();
            services.AddDbContext<DemoContext>(options =>
               options.UseSqlServer(connectionString));

            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<DemoContext>();


            using (var serviceProvider = services.BuildServiceProvider())
            {
                using (var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    var context = scope.ServiceProvider.GetService<DemoContext>();
                    context.Database.Migrate();

                    var userMgr = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
                    var user1 = userMgr.FindByNameAsync("alice").Result;
                    if (user1 == null)
                    {
                        user1 = new IdentityUser
                        {
                            UserName = "Ziham",
                            Email = "Ziham@email.com",
                            EmailConfirmed = true,
                        };
                        var result = userMgr.CreateAsync(user1, "Pass123$").Result;
                        if (!result.Succeeded)
                        {
                            throw new Exception(result.Errors.First().Description);
                        }

                        result = userMgr.AddToRoleAsync(user1, "Public").Result;
                        if (!result.Succeeded)
                        {
                            throw new Exception(result.Errors.First().Description);
                        }
                    }

                    var user2 = userMgr.FindByNameAsync("bob").Result;
                    if (user2 == null)
                    {
                        user2 = new IdentityUser
                        {
                            UserName = "bob",
                            Email = "BobSmith@email.com",
                            EmailConfirmed = true
                        };
                        var result = userMgr.CreateAsync(user2, "Pass123$").Result;
                        if (!result.Succeeded)
                        {
                            throw new Exception(result.Errors.First().Description);
                        }

                        result = userMgr.AddToRoleAsync(user2, "Company").Result;

                        if (!result.Succeeded)
                        {
                            throw new Exception(result.Errors.First().Description);
                        }
                    }
                }
            }
        }
    }
}

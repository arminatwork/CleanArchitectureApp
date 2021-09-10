using CA.Domain.Consts;
using CA.Domain.Entities;
using CA.Domain.ValueObjects;
using CA.Infrastructure.Identity;
using CA.Infrastructure.Persistence.Data.BaseRepository;
using CA.SharedKernel.Consts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CA.Infrastructure.Persistence
{
    public static class AppDbContextSeed
    {
        public static async Task SeedDefaultUserAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            var roles = new List<IdentityRole>()
            {
                new (Roles.Admin),
                new (Roles.Basic)
            };
            foreach (var role in roles)
            {
                if (await roleManager.Roles.AllAsync(_ => _.Name != role.Name))
                {
                    await roleManager.CreateAsync(role);
                }
            }

            User admin = new()
            {
                UserName = Users.SeedUserName,
                Email = Users.SeedEmail
            };
            if (await userManager.Users.AllAsync(_ => _.UserName != admin.UserName))
            {
                await userManager.CreateAsync(admin, Users.SeedPassword);
                await userManager.AddToRoleAsync(admin, Roles.Admin);
            }
        }

        public static async Task SeedTodoData(IRepository<TodoList> repository, CancellationToken cancellationToken)
        {
            if (!await repository.IsExistsAsync(cancellationToken))
            {
                TodoList list = new()
                {
                    Title = "Programming",
                    Color = Color.Blue,
                    Items =
                    {
                        new TodoItem{Title="CSharp",Done=true},
                        new TodoItem{Title="React",Done=true},
                        new TodoItem{Title="Python"},
                        new TodoItem{Title="Scrum"},
                        new TodoItem{Title="Agile"},
                        new TodoItem{Title="Clean Architecture"},
                    }
                };

                await repository.AddAsync(list, cancellationToken);
                await repository.SaveAsync(cancellationToken);
            }
        }
    }
}
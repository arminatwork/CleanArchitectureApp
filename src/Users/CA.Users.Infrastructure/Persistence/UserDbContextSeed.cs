namespace CA.Users.Infrastructure.Persistence;

public class UserDbContextSeed
{
    //public static async Task SeedDefaultUserAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
    //{
    //    var roles = new List<IdentityRole>()
    //    {
    //        new (Roles.Admin),
    //        new (Roles.Basic)
    //    };
    //    foreach (var role in roles)
    //    {
    //        if (await roleManager.Roles.AllAsync(_ => _.Name != role.Name))
    //        {
    //            await roleManager.CreateAsync(role);
    //        }
    //    }

    //    User admin = new()
    //    {
    //        UserName = Users.SeedUserName,
    //        Email = Users.SeedEmail
    //    };
    //    if (await userManager.Users.AllAsync(_ => _.UserName != admin.UserName))
    //    {
    //        await userManager.CreateAsync(admin, Users.SeedPassword);
    //        await userManager.AddToRoleAsync(admin, Roles.Admin);
    //    }
    //}
}

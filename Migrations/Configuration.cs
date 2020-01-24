namespace jspBlog.Migrations
{
    using jspBlog.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<jspBlog.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "jspBlog.Models.ApplicationDbContext";
        }

        protected override void Seed(Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            var roleManager = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(context));

            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                roleManager.Create(new IdentityRole { Name = "Admin" });
            }

            if (!context.Roles.Any(r => r.Name == "Moderator"))
            {
                roleManager.Create(new IdentityRole { Name = "Moderator" });
            }

            if (!context.Roles.Any(r => r.Name == "User"))
            {
                roleManager.Create(new IdentityRole { Name = "User" });
            }

            if (!context.Roles.Any(r => r.Name == "Guest"))
            {
                roleManager.Create(new IdentityRole { Name = "Guest" });
            }

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (!context.Users.Any(u => u.Email == "laymanscode@gmail.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "laymanscode@gmail.com",
                    Email = "laymanscode@gmail.com",
                    FirstName = "Joshua",
                    LastName = "Patterson",
                    DisplayName = "Josh"
                }, "Abc&123!");
            }

            var userId = userManager.FindByEmail("laymanscode@gmail.com").Id;
            userManager.AddToRole(userId, "Admin");

            if (!context.Users.Any(u => u.Email == "moderator@codefoundry.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "moderator@codefoundry.com",
                    Email = "moderator@codefoundry.com",
                    FirstName = "CF",
                    LastName = "Moderator",
                    DisplayName = "CFMOD"
                }, "Abc&123!");
            }

            userId = userManager.FindByEmail("moderator@codefoundry.com").Id;
            userManager.AddToRole(userId, "Moderator");
        }
    }
}
namespace BootcampMvc.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using BootcampMvc.Models;

    // this class is generated by using enable-migrations on NuGet Package Manager console
    internal sealed class Configuration : DbMigrationsConfiguration<BootcampMvc.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            // set to true 
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(BootcampMvc.Models.ApplicationDbContext context)
        {
            // this is where update function placed when Web updating the database
            // run 'update-database' on NuGet Package Manager console to update/create tables in database
            // option : 
            //          -script  : generate SQL query script
            //          -verbose : show details in console during process
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            if (!context.Users.Any(u => u.UserName=="admin"))
            {
                // code to generate new user and its role
                var user = new ApplicationUser { UserName = "admin" };
                userManager.Create(user, "miqbal.23");
                roleManager.Create(new IdentityRole { Name = "Administrators" });
                userManager.AddToRole(user.Id, "Administrators");
            }

            if (!context.Users.Any(u => u.UserName == "user1"))
            {
                // code to generate new user and its role
                var user = new ApplicationUser { UserName = "user1" };
                userManager.Create(user, "123.45");
                roleManager.Create(new IdentityRole { Name = "Members" });
                userManager.AddToRole(user.Id, "Members");
            }
        }
    }
}
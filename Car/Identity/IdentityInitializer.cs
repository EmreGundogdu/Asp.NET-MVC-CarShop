using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

namespace Car.Identity
{
    public class IdentityInitializer:CreateDatabaseIfNotExists<IdentityDataContext>
    {
        protected override void Seed(IdentityDataContext context)
        {
            if (!context.Roles.Any(i=>i.Name=="admin"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);
                var role = new ApplicationRole(){Name="admin",Description="admin role" };
                manager.Create(role);
            }
            if (!context.Roles.Any(i => i.Name == "user"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);
                var role = new ApplicationRole() { Name = "user", Description = "user role" };
                manager.Create(role);
            }
            if (!context.Users.Any(i=>i.Name=="EmreGundogdu"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser() {Name="Emre",Surname="Gundogdu",UserName="emregundogdu",Email="emre26gundogdu@gmail.com" };
                manager.Create(user,"12345");
                manager.AddToRole(user.Id,"admin");
                manager.AddToRole(user.Id,"user");
            }
            if (!context.Users.Any(i => i.Name == "FatihOzturk"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser() { Name = "Fatih", Surname = "Ozturk", UserName = "fatihozturk", Email = "fakecry26@gmail.com" };
                manager.Create(user, "12345");
                manager.AddToRole(user.Id, "user");
            }
            base.Seed(context);
        }
    }
}
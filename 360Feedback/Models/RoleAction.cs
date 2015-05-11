using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using _360Feedback.Models;

namespace _360Feedback.Models
{
    internal class RoleAction
    {

        internal void AddUserAndRole()
        {
            // Access the application context and create result variables.
            Models.ApplicationDbContext context = new ApplicationDbContext();
            IdentityResult IdRoleResult;
            IdentityResult IdUserResult;

            // Create a RoleStore object by using the ApplicationDbContext object. 
            // The RoleStore is only allowed to contain IdentityRole objects.
            var roleStore = new RoleStore<IdentityRole>(context);

            // Create a RoleManager object that is only allowed to contain IdentityRole objects.
            // When creating the RoleManager object, you pass in (as a parameter) a new Role object. 
            var roleMgr = new RoleManager<IdentityRole>(roleStore);


            if (!roleMgr.RoleExists("administrator"))
            {
                IdRoleResult = roleMgr.Create(new IdentityRole { Name = "administrator" });
            }

            var userMgr = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var appUser = new ApplicationUser
            {
                UserName = "wctcemailtest@gmail.com",
                Email = "wctcemailtest@gmail.com"
            };
            IdUserResult = userMgr.Create(appUser, "P@ssw0rd");

            if (!userMgr.IsInRole(userMgr.FindByEmail("wctcemailtest@gmail.com").Id, "administrator"))
            {
                IdUserResult = userMgr.AddToRole(userMgr.FindByEmail("wctcemailtest@gmail.com").Id, "administrator");
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using EasyMealCore.DomainModel;

namespace EF_MSSQL_Identity_DataStore
{
    public class SeedDataIdentity
    {
        private const string adminUser = "Admin";
        private const string adminPassword = "Secret123$";
        private const string adminEmail = "admin@gmail.com";
        private static DateTime dob = new DateTime(2017, 1, 8);

        public static async Task EnsurePopulated(UserManager<ApplicationUser> userManager)
        {
            ApplicationUser user = await userManager.FindByIdAsync(adminUser);
            if (user == null)
            {
                user = new ApplicationUser { UserName = adminUser, Email = adminEmail, DOB = dob };
                await userManager.CreateAsync(user, adminPassword);
            }
        }
    }
}

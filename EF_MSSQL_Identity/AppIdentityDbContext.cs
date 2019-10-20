using System;
using System.Collections.Generic;
using System.Text;
using EasyMealCore.DomainModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EF_MSSQL_Identity_DataStore
{
    public class AppIdentityDbContext : IdentityDbContext<ApplicationUser> { 
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options)
            : base(options)
        {
        }
    }
}

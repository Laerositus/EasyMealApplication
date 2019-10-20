using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Design;

using System;
using System.Collections.Generic;
using EasyMealCore.DomainModel;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Logging;

namespace EF_MSSQL_DataStore
{
    public class ApplicationDbContext : DbContext
    {
        [Obsolete]
        public static readonly LoggerFactory MyLoggerFactory
            = new LoggerFactory(new[] { new ConsoleLoggerProvider((_, __) => true, true) });
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
             => optionsBuilder
                .UseLoggerFactory(MyLoggerFactory); // Warning: Do not create a new ILoggerFactory instance each time
              

        public DbSet<Meal> Meals { get; set; }

        public DbSet<MealWeek> MealWeeks { get; set; }

        public DbSet<Order> Orders { get; set; }


        //internal void AttachRange(IEnumerable<Meal> enumerable)
        //{
        //    throw new NotImplementedException();
        //}
    }
}

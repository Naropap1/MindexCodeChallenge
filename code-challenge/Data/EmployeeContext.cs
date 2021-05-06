using challenge.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace challenge.Data
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //define foreign key for one to one relationship
            modelBuilder.Entity<Employee>().HasOne(e => e.Compensation).WithOne(c => c.Employee).HasForeignKey<Compensation>(c => c.EmployeeId);
        }

        public DbSet<Employee> Employees { get; set; }
        //created a new DbSet for compensations - as requested
        public DbSet<Compensation> Compensations { get; set; }
    }
}

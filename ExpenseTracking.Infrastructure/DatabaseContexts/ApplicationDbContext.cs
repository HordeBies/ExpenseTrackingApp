﻿using ExpenseTracking.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracking.Infrastructure.DatabaseContexts
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Transaction> Transactions { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ApplicationUser>().Property(x => x.ReceiveDailyReports).HasDefaultValue(false);
            modelBuilder.Entity<ApplicationUser>().Property(x => x.ReceiveWeeklyReports).HasDefaultValue(false);
            modelBuilder.Entity<ApplicationUser>().Property(x => x.ReceiveMonthlyReports).HasDefaultValue(false);
        }
    }

}

using BioscoopSysteemWebsite.Domain.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioscoopSysteemWebsite.Domain.Concrete
{
    public class ApplicationDbContext : IdentityDbContext<BackofficeUser, BackofficeRole, string, IdentityUserLogin, IdentityUserRole, IdentityUserClaim>
    {
        public ApplicationDbContext()
            : base("DbContext")
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Pegi> Pegis { get; set; }
        public DbSet<Show> Shows { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketSoort> TicketSoort { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Mail> Emails { get; set; }
        public DbSet<LadiesNight> LadiesNights { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<BackofficeUser>()
                .ToTable("BackofficeUsers", "dbo");
            modelBuilder.Entity<BackofficeRole>()
                .ToTable("BackofficeRoles", "dbo");
            modelBuilder.Entity<IdentityUserClaim>()
                .ToTable("BackofficeUserClaims", "dbo");
            modelBuilder.Entity<IdentityUserLogin>()
                .ToTable("BackofficeUserLogins", "dbo");
            modelBuilder.Entity<IdentityUserRole>()
                .ToTable("BackofficeUserRoles", "dbo");
        }
    }
}

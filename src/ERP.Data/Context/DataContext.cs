using ERP.Business.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace ERP.Data.Context
{
    public class DataContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid,
        IdentityUserClaim<Guid>, ApplicationUserRole, IdentityUserLogin<Guid>,
        IdentityRoleClaim<Guid>, IdentityUserToken<Guid>>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<BackOfficeUser> BackOfficeUsers { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<PhysicalPerson> PhysicalPersons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);

            #region Filter Deleted

            modelBuilder.Entity<ApplicationUser>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<BackOfficeUser>().HasQueryFilter(p => !p.IsDeleted);

            #endregion

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUserRole>(userRole =>
            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                userRole.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                userRole.HasOne(ur => ur.User)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });

            modelBuilder.Entity<ApplicationUser>().HasIndex(x => x.NormalizedUserName)
                .IsUnique(false)
                .HasName("UserNameIndex");
            modelBuilder.Entity<ApplicationUser>().Property(u => u.UserName)
                .IsRequired()
                .HasMaxLength(256);
        }
    }
}

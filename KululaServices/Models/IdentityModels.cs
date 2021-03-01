using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System.Data.Entity;
using System;

namespace KululaServices.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public Guid ActivationCode { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("kululaSecurity", throwIfV1Schema: false)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IdentityUser>().ToTable("KululaUser");
            modelBuilder.Entity<ApplicationUser>().ToTable("KululaUser");

            modelBuilder.Entity<IdentityRole>().ToTable("KululaRoles");
            modelBuilder.Entity<IdentityUserRole>().ToTable("KululaUserRoles");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("KululaUserClaim");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("KululaUserLogin");
            

        }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public class AccountVerificationModel
        {
            public string OTP { get; set; }
            public string ActivationC { get; set; }
        }
    }
}
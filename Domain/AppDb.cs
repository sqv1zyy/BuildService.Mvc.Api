using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BuildService.Mvc.Api.Domain.Entities;

namespace BuildService.Mvc.Api.Domain
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<ServiceCategory> ServiceCategories { get; set; } = null!;
        public DbSet<Service> Services { get; set; } = null!;

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            string adminName = "admin";
            string roleAdminId = "E6B29BA3-70C5-4D0B-B23B-F78186438B19";
            string userAdminId = "18C16A48-321D-4765-AF34-99AB99B343F0";
            string adminPasswordHash = "AQAAAAIAAYagAAAAEG4Pxl+CvlJ/L31x3/9B1V1PqR+S413B6pI4O+aG+J5h+yB==";
            string _email = adminName.ToUpper();

            // Добавление роли админа

            builder.Entity<IdentityRole>().HasData(new IdentityRole()
            {
                Id = roleAdminId,
                Name = adminName,
                NormalizedName = adminName.ToUpper()
            });

            // Пользователь с админкой

            builder.Entity<IdentityUser>().HasData(new IdentityUser()
            {
                Id = userAdminId,
                UserName = adminName,
                NormalizedUserName = adminName.ToUpper(),
                Email = _email,
                NormalizedEmail = _email,
                EmailConfirmed = true,
                PasswordHash = adminPasswordHash,
                PhoneNumberConfirmed = true,

            });

            builder.Entity<IdentityUserRole<string>>()
                .HasData(new IdentityUserRole<string>()
            {
                RoleId = roleAdminId,
                UserId = userAdminId
            });
        }


    }
}
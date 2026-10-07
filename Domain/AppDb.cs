using BuildService.Mvc.Api.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

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
            string _email = adminName.ToUpper();

            var adminUser = new IdentityUser()
            {
                Id = userAdminId,
                UserName = adminName,
                NormalizedUserName = adminName.ToUpper(),
                Email = _email,
                NormalizedEmail = _email,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = "B4C2518D-065C-4F71-B67B-01B6B2B289C8",
                ConcurrencyStamp = "C8F53A02-9988-4A51-A3C2-821B0F2104E9"
            };

            // Динамически генерируем валидный хэш для пароля "admin"
            var hasher = new PasswordHasher<IdentityUser>();
            adminUser.PasswordHash = hasher.HashPassword(adminUser, "admin");

            // Добавление роли админа

            builder.Entity<IdentityRole>().HasData(new IdentityRole()
            {
                Id = roleAdminId,
                Name = adminName,
                NormalizedName = adminName.ToUpper()
            });

            // Пользователь с админкой

            builder.Entity<IdentityUser>().HasData(adminUser);

            builder.Entity<IdentityUserRole<string>>()
                .HasData(new IdentityUserRole<string>()
                {
                    RoleId = roleAdminId,
                    UserId = userAdminId
                });       
        }
    }
}
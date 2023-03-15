using SurveyTest.Business.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyTest.Business.Models.SeedContext
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            // Any guid
            var roleId = Guid.Parse("9373ea95-3192-404c-b029-ef1f4b1bb847");
            var roleUserId = Guid.Parse("6e713abd-15ae-4232-9d2f-2a644bb70165");
            var adminId = Guid.NewGuid();
            var userId = Guid.NewGuid();
            var userId2 = Guid.NewGuid();

            modelBuilder.Entity<AppRoles>().HasData(new AppRoles
            {
                Id = roleId,
                Name = "Admin",
                NormalizedName = "ADMIN",
            });
            modelBuilder.Entity<AppRoles>().HasData(new AppRoles
            {
                Id = roleUserId,
                Name = "Users",
                NormalizedName = "USERS",
            });

            var hasher = new PasswordHasher<AppUsers>();

            modelBuilder.Entity<AppUsers>().HasData(new AppUsers
            {
                Id = adminId,
                IDSV = 12345,
                UserName = "12345@hypercoder.tech",
                NormalizedUserName = "12345@hypercoder.tech",
                Email = "12345@hypercoder.tech",
                NormalizedEmail = "12345@HYPERCODER.TECH",
                Firstname = "Nam",
                Lastname = "Trần Thanh",
                EmailConfirmed = true,
                PhoneNumber = "0968354148",
                PasswordHash = hasher.HashPassword(null, "Abc@12345"),
                SecurityStamp = string.Empty,
                Address = "Hòa Quý, Ngũ Hành Sơn, Tp.Đà Nẵng",
            });
            modelBuilder.Entity<AppUsers>().HasData(new AppUsers
            {
                Id = userId,
                IDSV = 44444,
                UserName = "44444@hypercoder.tech",
                NormalizedUserName = "44444@hypercoder.tech",
                Email = "44444@hypercoder.tech",
                NormalizedEmail = "44444@HYPERCODER.TECH",
                Firstname = "A",
                Lastname = "Trần Thanh",
                EmailConfirmed = true,
                PhoneNumber = "0968354148",
                PasswordHash = hasher.HashPassword(null, "Abc@12345"),
                SecurityStamp = string.Empty,
                Address = "Hòa Quý, Ngũ Hành Sơn, Tp.Đà Nẵng",
            });
            modelBuilder.Entity<AppUsers>().HasData(new AppUsers
            {
                Id = userId2,
                IDSV = 55555,
                UserName = "55555@hypercoder.tech",
                NormalizedUserName = "55555@hypercoder.tech",
                Email = "55555@hypercoder.tech",
                NormalizedEmail = "55555@HYPERCODER.TECH",
                Firstname = "B",
                Lastname = "Trần Thanh",
                EmailConfirmed = true,
                PhoneNumber = "0968354148",
                PasswordHash = hasher.HashPassword(null, "Abc@12345"),
                SecurityStamp = string.Empty,
                Address = "Hòa Quý, Ngũ Hành Sơn, Tp.Đà Nẵng",
            });

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = roleId,
                UserId = adminId
            });
            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = roleUserId,
                UserId = userId

            });
            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = roleUserId,
                UserId = userId2
            });

            var viewId = Guid.NewGuid();
            var viewId2 = Guid.NewGuid();
            var viewId3 = Guid.NewGuid();
            modelBuilder.Entity<Tablet>().HasData(new Tablet
            {
                Id = viewId,
                Name = "Chọn",
                Type = 1,
                IsActive = false,
                CreatedDate = DateTime.Now,
                CreatedTime = DateTime.Now,
                CreatedBy = "",
                DeletedBy = "",
                IsDeleted = false,
                ModifiedBy = "",
                ModifiedDate = DateTime.Now,
                ModifiedTime = DateTime.Now
            });
            modelBuilder.Entity<Tablet>().HasData(new Tablet
            {
                Id = viewId2,
                Name = "Bình chọn",
                Type = 2,
                IsActive = false,
                CreatedDate = DateTime.Now,
                CreatedTime = DateTime.Now,
                CreatedBy = "",
                DeletedBy = "",
                IsDeleted = false,
                ModifiedBy = "",
                ModifiedDate = DateTime.Now,
                ModifiedTime = DateTime.Now
            });
            modelBuilder.Entity<Tablet>().HasData(new Tablet
            {
                Id = viewId3,
                Name = "Dữ liệu",
                Type = 3,
                IsActive = false,
                CreatedDate = DateTime.Now,
                CreatedTime = DateTime.Now,
                CreatedBy = "",
                DeletedBy = "",
                IsDeleted = false,
                ModifiedBy = "",
                ModifiedDate = DateTime.Now,
                ModifiedTime = DateTime.Now
            });
        }
    }
}

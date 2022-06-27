using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rbac.Entity
{

    //上下文类
    public class MyDbContext: DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }

        public DbSet<Role> Role { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<MenuRole> MenuRole { get; set; }
        public DbSet<UserRole> UserRole { get; set; }


        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //给各个表添加约束
            modelBuilder.Entity<Menu>(m =>
            {
                m.Property(m => m.MenuName).HasMaxLength(50).IsRequired();
                m.Property(m => m.LinkUrl).HasMaxLength(50).IsRequired();
            });

            modelBuilder.Entity<User>(m =>
            {
                m.Property(m => m.UserName).HasMaxLength(50).IsRequired();
                m.Property(m => m.Password).HasMaxLength(50).IsRequired();
                m.Property(m => m.Email).HasMaxLength(50).IsRequired();
                m.Property(m => m.LastLoginIP).HasMaxLength(50);
            });

            modelBuilder.Entity<Role>(m =>
            {
                m.Property(m => m.RoleName).HasMaxLength(50).IsRequired();
            });

            //中间表的外键约束
            modelBuilder.Entity<MenuRole>(m =>
            {
                m.HasOne<Menu>().WithMany().HasForeignKey(x => x.MenuId);
                m.HasOne<Role>().WithMany().HasForeignKey(x => x.RoleId);
            });

            modelBuilder.Entity<UserRole>(m =>
            {
                m.HasOne<User>().WithMany().HasForeignKey(x => x.UserId);
                m.HasOne<Role>().WithMany().HasForeignKey(x => x.RoleId);
            });
        }
    }
}

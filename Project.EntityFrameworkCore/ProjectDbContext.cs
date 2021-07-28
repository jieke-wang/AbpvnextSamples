using Microsoft.EntityFrameworkCore;
using Project.Domain.AccountDomain;
using Volo.Abp.EntityFrameworkCore;

namespace Project.EntityFrameworkCore {
    public class ProjectDbContext : AbpDbContext<ProjectDbContext> {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountAddress> AccountAddresses { get; set; }

        public ProjectDbContext (DbContextOptions<ProjectDbContext> options) : base (options) { }

        protected override void OnModelCreating (ModelBuilder modelBuilder) {
            base.OnModelCreating (modelBuilder);

            modelBuilder.Entity<Account> (entity => {
                entity.HasKey (k => k.Id); // 设置主键
                entity.Property (p => p.Id).ValueGeneratedOnAdd (); // 设置Id系统自增
                entity.Property (p => p.Username).IsRequired ().HasMaxLength (20).IsUnicode (); // 设置Username为必填且最大长度为20的Unicode字符串
                entity.Property (p => p.Password).IsRequired ().HasMaxLength (200);
            });

            modelBuilder.Entity<AccountAddress> (entity => {
                entity.HasKey (k => k.Id);
                entity.Property (p => p.Id).ValueGeneratedOnAdd ();
                entity.Property (p => p.AccountId).IsRequired ();
                entity.Property (p => p.Province).IsRequired ().HasMaxLength (20).IsUnicode ();
                entity.Property (p => p.City).IsRequired ().HasMaxLength (20).IsUnicode ();
                entity.Property (p => p.Region).HasMaxLength (20).IsUnicode ();
                entity.Property (p => p.Detailedaddress).IsRequired ().HasMaxLength (50).IsUnicode ();
            });
        }
    }
}
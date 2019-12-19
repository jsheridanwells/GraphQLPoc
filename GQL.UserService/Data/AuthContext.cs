using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GQL.UserService.Data
{
    public class AuthContext : DbContext
    {
        public AuthContext(DbContextOptions<AuthContext> opts) : base(opts) { }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<ApiKeyEntity> ApiKeys { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserEntity>()
                .HasKey(k => k.Id);
            builder.Entity<UserEntity>()
                .HasIndex(u => u.Email)
                .IsUnique();

            builder.Entity<ApiKeyEntity>()
                .HasKey(k => k.Id);
            builder.Entity<ApiKeyEntity>()
                .Property(x => x.Roles)
                .HasConversion(
                    x => string.Join(',', x),
                    x => x.Split(',', StringSplitOptions.RemoveEmptyEntries)
                );            
        }
    }
}

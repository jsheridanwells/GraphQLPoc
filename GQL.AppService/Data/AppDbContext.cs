using Microsoft.EntityFrameworkCore;

namespace GQL.AppService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opts) : base(opts) { }

        public DbSet<Weight> Weights { get; set; }
        public DbSet<Calorie> Calories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Weight>()
                .HasKey(w => w.Id);
            builder.Entity<Weight>()
                .Property(w => w.WeightUnit)
                .HasConversion<string>();
            builder.Entity<Weight>()
                .Property(w => w.CreatedDate)
                .HasDefaultValueSql("GETDATE()");
            builder.Entity<Weight>()
                .Property(w => w.Amount)
                .HasColumnType("decimal");


            builder.Entity<Calorie>()
                .HasKey(c => c.Id);
            builder.Entity<Calorie>()
                .Property(c => c.CreatedDate)
                .HasDefaultValueSql("GETDATE()");
        }
    }
}

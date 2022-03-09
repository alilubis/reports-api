using APITest.Model;
using Microsoft.EntityFrameworkCore;
namespace APITest.Model
{
    public class QualityDBContext : DbContext
    {
        public QualityDBContext(DbContextOptions<QualityDBContext> options) : base(options) { }

        public DbSet<DailyQC> DailyQC { get; set; }
        public DbSet<DailyQCFDI> DailyQCFDI { get; set; }
        public DbSet<MonthlyQC> MonthlyQC { get; set; }
        public DbSet<MonthlyQCFDI> MonthlyQCFDI { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<DailyQC>()
                .ToView("vDailyQC")
                .HasKey(x => new { x.Date, x.Operation, x.ProductType });
            builder.Entity<DailyQCFDI>()
                .ToView("vDailyQCFDI")
                .HasKey(x => new { x.Date, x.ProductType });
            builder.Entity<MonthlyQC>()
                .ToView("vMonthlyQC")
                .HasKey(x => new { x.Date, x.Operation, x.ProductType });
            builder.Entity<MonthlyQCFDI>()
                .ToView("vMonthlyQCFDI")
                .HasKey(x => new { x.Date, x.Operation });
        }
    }
}
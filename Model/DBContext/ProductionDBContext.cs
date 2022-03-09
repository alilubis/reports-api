using APITest.Model;
using Microsoft.EntityFrameworkCore;
namespace APITest.Model
{
    public class ProductionDBContext : DbContext
    {
        public ProductionDBContext(DbContextOptions<ProductionDBContext> options) : base(options) { }

        public DbSet<DailyOutputSiHy> DailyOutputSiHy { get; set; }
        public DbSet<OperationSiHy> OperationSiHy { get; set; }
        public DbSet<DailyPOCloseSiHy> DailyPOCloseSiHy { get; set; }
        public DbSet<DailyOutputFL> DailyOutputFL { get; set; }
        public DbSet<OperationFL> OperationFL { get; set; }
        public DbSet<DailyPOCloseFL> DailyPOCloseFL { get; set; }
        public DbSet<MonthlyOutputSiHy> MonthlyOutputSiHy { get; set; }
        public DbSet<MonthlyPOCloseSiHy> MonthlyPOCloseSiHy { get; set; }
        public DbSet<MonthlyOutputFL> MonthlyOutputFL { get; set; }
        public DbSet<MonthlyPOCloseFL> MonthlyPOCloseFL { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<DailyOutputSiHy>()
                .ToView("vDailyOutputSihy")
                .HasKey(x => new { x.Date, x.Operation, x.ProductType });
            builder.Entity<OperationSiHy>()
                .ToView("vOperationSiHy")
                .HasKey(x => x.Operation);
            builder.Entity<DailyPOCloseSiHy>()
                .ToView("vDailyPOCloseSiHy")
                .HasKey(x => new { x.Date, x.ProductType });
            builder.Entity<DailyOutputFL>()
                .ToView("vDailyOutputFL")
                .HasKey(x => new { x.Date, x.Operation, x.ProductType });
            builder.Entity<OperationFL>()
                .ToView("vOperationFL")
                .HasKey(x => x.Operation);
            builder.Entity<DailyPOCloseFL>()
                .ToView("vDailyPOCloseFL")
                .HasKey(x => new { x.Date, x.ProductType });
            builder.Entity<MonthlyOutputSiHy>()
                .ToView("vMonthlyOutputSiHy")
                .HasKey(x => new { x.Date, x.Operation, x.ProductType });
            builder.Entity<MonthlyPOCloseSiHy>()
                .ToView("vMonthlyPOCloseSiHy")
                .HasKey(x => new { x.Date, x.ProductType });
            builder.Entity<MonthlyOutputFL>()
                .ToView("vMonthlyOutputFL")
                .HasKey(x => new { x.Date, x.Operation, x.ProductType });
            builder.Entity<MonthlyPOCloseFL>()
                .ToView("vMonthlyPOCloseFL")
                .HasKey(x => new { x.Date, x.ProductType });
        }
    }
}
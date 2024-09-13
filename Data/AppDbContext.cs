using Microsoft.EntityFrameworkCore;
using FinancialTransactionsAPI.Models;

namespace FinancialTransactionsAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<FinancialTransaction> FinancialTransactions { get; set; }
    }
}
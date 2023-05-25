using CashFlow.Domain;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infra.Data;

 public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
    }

    public DbSet<Transaction> Transactions { get; set; }

}

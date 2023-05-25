using CashFlow.Domain;
using CashFlow.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infra.Repositories;

public class TransactionEFRepository: ITransactionRepository
{
    private readonly DataContext _context;

    public TransactionEFRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<List<Transaction>> GetAllAsync() =>
        await _context.Transactions.ToListAsync();

    public async Task<Transaction> GetByIdAsync(int id) =>
        await _context.Transactions.FirstOrDefaultAsync(l => l.Id == id);

    public async Task CreateAsync(Transaction lancamento)
    {
        _context.Transactions.Add(lancamento);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Transaction lancamento)
    {
        _context.Transactions.Update(lancamento);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var lancamento = await _context.Transactions.FirstOrDefaultAsync(l => l.Id == id);
        if (lancamento != null)
        {
            _context.Transactions.Remove(lancamento);
            await _context.SaveChangesAsync();
        }
    }
}

using ExpenseTracking.Domain.Entities;
using ExpenseTracking.Domain.RepositoryContracts;
using ExpenseTracking.Infrastructure.DatabaseContexts;

namespace ExpenseTracking.Infrastructure.Repositories
{
    public class TransactionRepository(ApplicationDbContext db) : Repository<Transaction>(db), ITransactionRepository
    {
    }
}

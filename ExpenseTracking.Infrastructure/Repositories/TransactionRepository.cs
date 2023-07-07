using ExpenseTracking.Domain.RepositoryContracts;
using ExpenseTracking.Infrastructure.DatabaseContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ExpenseTracking.Infrastructure.Repositories
{
    public class TransactionRepository(ApplicationDbContext db): Repository<Transaction>(db), ITransactionRepository
    {
    }
}

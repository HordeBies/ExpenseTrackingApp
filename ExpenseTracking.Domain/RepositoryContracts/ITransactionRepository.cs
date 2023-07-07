using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ExpenseTracking.Domain.RepositoryContracts
{
    public interface ITransactionRepository: IRepository<Transaction>
    {
    }
}

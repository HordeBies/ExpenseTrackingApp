using ExpenseTracking.Core.DTO;

namespace ExpenseTracking.Core.ServiceContracts
{
    public interface ITransactionService
    {
        public Task<TransactionResponse> CreateNewTransaction(TransactionCreateRequest request);
        public Task<IEnumerable<TransactionResponse>> GetAllTransactions();
        public Task<TransactionResponse> GetTransactionById(int id);
        public Task UpdateTransaction(TransactionUpdateRequest request);
        public Task DeleteTransaction(int id);
    }
}

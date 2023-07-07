using AutoMapper;
using ExpenseTracking.Core.DTO;
using ExpenseTracking.Core.ServiceContracts;
using ExpenseTracking.Domain.Entities;
using ExpenseTracking.Domain.RepositoryContracts;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace ExpenseTracking.Core.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository transactionRepository;
        private readonly IMapper mapper;
        private readonly ClaimsPrincipal user;
        private string UserId => user.FindFirstValue(ClaimTypes.Name);
        public TransactionService(IHttpContextAccessor httpContextAccessor, ITransactionRepository transactionRepository, IMapper mapper)
        {
            user = (httpContextAccessor.HttpContext?.User) ?? throw new Exception("Client is not authorized");

            this.transactionRepository = transactionRepository;
            this.mapper = mapper;
        }
        public async Task<TransactionResponse> CreateNewTransaction(TransactionCreateRequest request)
        {
            var transaction = mapper.Map<Transaction>(request);
            transaction.UserId = UserId;
            await transactionRepository.CreateAsync(transaction);
            await transactionRepository.SaveAsync();
            return mapper.Map<TransactionResponse>(transaction);
        }
        public async Task<IEnumerable<TransactionResponse>> GetAllTransactions()
        {
            var transactions = await transactionRepository.GetAllAsync(r => r.UserId == UserId);
            return mapper.Map<IEnumerable<TransactionResponse>>(transactions);
        }
        public async Task<TransactionResponse> GetTransactionById(int id)
        {
            var transaction = await transactionRepository.GetAsync(r => r.Id == id && r.UserId == UserId);
            return mapper.Map<TransactionResponse>(transaction);
        }
        public async Task UpdateTransaction(TransactionUpdateRequest request)
        {
            var transaction = await transactionRepository.GetAsync(r => r.Id == request.Id && r.UserId == UserId) ?? throw new Exception("Transaction not found");
            transaction = mapper.Map(request, transaction);
            await transactionRepository.UpdateAsync(transaction);
            await transactionRepository.SaveAsync();
        }
        public async Task DeleteTransaction(int id)
        {
            var transaction = await transactionRepository.GetAsync(r => r.Id == id && r.UserId == UserId) ?? throw new Exception("Transaction not found");
            await transactionRepository.DeleteAsync(transaction);
            await transactionRepository.SaveAsync();
        }
    }
}

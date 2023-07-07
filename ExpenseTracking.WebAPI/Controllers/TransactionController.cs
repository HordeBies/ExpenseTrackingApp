using ExpenseTracking.Core.DTO;
using ExpenseTracking.Core.ServiceContracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ExpenseTracking.WebAPI.Controllers
{
    [ApiController]
    [Route("api/transaction")]
    [Authorize]
    public class TransactionController(ITransactionService transactionService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransactionResponse>>> GetTransactions()
        {
            var response = await transactionService.GetAllTransactions();
            return Ok(response);
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetTransaction(int id)
        {
            var response = await transactionService.GetTransactionById(id);
            return Ok(response);
        }
        [HttpPost]
        public async Task<ActionResult> CreateTransaction(TransactionCreateRequest request)
        {
            var response = await transactionService.CreateNewTransaction(request);
            return Ok(response);
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateTransaction(int id, TransactionUpdateRequest request)
        {
            if(id != request.Id)
            {
                return BadRequest();
            }
            await transactionService.UpdateTransaction(request);
            return Ok();
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteTransaction(int id)
        {
            await transactionService.DeleteTransaction(id);
            return Ok();
        }


    }
}

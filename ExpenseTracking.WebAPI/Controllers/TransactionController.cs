using ExpenseTracking.Core.DTO;
using ExpenseTracking.Core.ServiceContracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracking.WebAPI.Controllers
{
    [ApiController]
    [Route("api/transaction")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class TransactionController(ITransactionService transactionService) : ControllerBase
    {
        /// <summary>
        /// Retrieves all transactions for the authorized user.
        /// </summary>
        /// <returns>A list of transactions.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<TransactionResponse>>> GetTransactions()
        {
            var response = await transactionService.GetAllTransactions();
            return Ok(response);
        }
        /// <summary>
        /// Retrieves a transaction by ID for the authorized user.
        /// </summary>
        /// <param name="id">The ID of the transaction.</param>
        /// <returns>The transaction with the specified ID.</returns>
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetTransaction(int id)
        {
            var response = await transactionService.GetTransactionById(id);
            if(response == null) return NotFound();
            return Ok(response);
        }
        /// <summary>
        /// Creates a new transaction for the authorized user.
        /// </summary>
        /// <param name="request">The transaction create request.</param>
        /// <returns>The created transaction.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<TransactionResponse>> CreateTransaction(TransactionCreateRequest request)
        {
            var response = await transactionService.CreateNewTransaction(request);
            return CreatedAtAction(nameof(GetTransaction),new { id = response.Id},response);
        }
        /// <summary>
        /// Updates a transaction for the authorized user.
        /// </summary>
        /// <param name="id">The ID of the transaction.</param>
        /// <param name="request">The updated transaction.</param>
        /// <returns>No content.</returns>
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UpdateTransaction(int id, TransactionUpdateRequest request)
        {
            if (id != request.Id)
            {
                return BadRequest();
            }
            await transactionService.UpdateTransaction(request);
            return NoContent();
        }
        /// <summary>
        /// Deletes a transaction for the authorized user.
        /// </summary>
        /// <param name="id">The ID of the transaction to delete.</param>
        /// <returns>No content.</returns>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult> DeleteTransaction(int id)
        {
            await transactionService.DeleteTransaction(id);
            return NoContent();
        }


    }
}

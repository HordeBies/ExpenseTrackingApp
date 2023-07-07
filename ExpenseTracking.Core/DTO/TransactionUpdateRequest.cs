using System.ComponentModel.DataAnnotations;

namespace ExpenseTracking.Core.DTO
{
    public class TransactionUpdateRequest
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [StringLength(100)]
        public string Description { get; set; }
    }
}

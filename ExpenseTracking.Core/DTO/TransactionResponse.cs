namespace ExpenseTracking.Core.DTO
{
    public class TransactionResponse
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
    }
}

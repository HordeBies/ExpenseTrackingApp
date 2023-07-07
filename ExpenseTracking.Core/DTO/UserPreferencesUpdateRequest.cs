using System.ComponentModel.DataAnnotations;

namespace ExpenseTracking.Core.DTO
{
    public class UserPreferencesUpdateRequest
    {
        [Required]
        public bool ReceiveDailyReports { get; set; }
        [Required]
        public bool ReceiveWeeklyReports { get; set; }
        [Required]
        public bool ReceiveMonthlyReports { get; set; }
    }
}

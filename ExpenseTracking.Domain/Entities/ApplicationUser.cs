using Microsoft.AspNetCore.Identity;

namespace ExpenseTracking.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public bool ReceiveDailyReports { get; set; }
        public bool ReceiveWeeklyReports { get; set; }
        public bool ReceiveMonthlyReports { get; set; }
    }
}

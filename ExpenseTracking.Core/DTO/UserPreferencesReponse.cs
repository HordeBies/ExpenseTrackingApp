namespace ExpenseTracking.Core.DTO
{
    public class UserPreferencesReponse
    {
        public bool ReceiveDailyReports { get; set; }
        public bool ReceiveWeeklyReports { get; set; }
        public bool ReceiveMonthlyReports { get; set; }
    }
}

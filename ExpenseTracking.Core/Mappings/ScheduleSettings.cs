namespace ExpenseTracking.Core.Mappings
{
    public class ScheduleSettings
    {
        public string DailyScheduleTime { get; set; }
        public string DailyJobId { get; set; }
        public string WeeklyScheduleTime { get; set; }
        public string WeeklyJobId { get; set; }
        public string MonthlyScheduleTime { get; set; }
        public string MonthlyJobId { get; set; }
    }
}

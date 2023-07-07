namespace ExpenseTracking.Core.ServiceContracts
{
    public interface IReportService
    {
        public Task SendDailyReports();
        public Task SendWeeklyReports();
        public Task SendMonthlyReports();
    }
}

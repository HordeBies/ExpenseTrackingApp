using ExpenseTracking.Core.Mappings;
using ExpenseTracking.Core.ServiceContracts;
using Hangfire;
using Microsoft.Extensions.Options;

namespace ExpenseTracking.Infrastructure.Initializers
{
    public class HangfireInitializer(IOptions<ScheduleSettings> options, IReportService reportService)
    {
        public async Task Initialize()
        {
            var scheduleSettings = options.Value;
            // After the initialization , the jobs will be executed according to the schedule settings. And the recurring initializations simply update the existing jobs.(in this case do nothing)
            RecurringJob.AddOrUpdate(recurringJobId:scheduleSettings.DailyJobId,methodCall: ()=> reportService.SendDailyReports(), cronExpression: scheduleSettings.DailyScheduleTime);
            RecurringJob.AddOrUpdate(recurringJobId: scheduleSettings.WeeklyJobId, methodCall: ()=> reportService.SendWeeklyReports(), cronExpression: scheduleSettings.WeeklyScheduleTime);
            RecurringJob.AddOrUpdate(recurringJobId: scheduleSettings.MonthlyJobId, methodCall: ()=> reportService.SendMonthlyReports(), cronExpression: scheduleSettings.MonthlyScheduleTime);
            
        }
    }
}

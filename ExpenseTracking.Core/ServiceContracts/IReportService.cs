using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracking.Core.ServiceContracts
{
    public interface IReportService
    {
        public Task SendDailyReports();
        public Task SendWeeklyReports();
        public Task SendMonthlyReports();
    }
}

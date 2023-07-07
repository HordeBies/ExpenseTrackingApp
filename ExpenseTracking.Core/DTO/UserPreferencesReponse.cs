using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracking.Core.DTO
{
    public class UserPreferencesReponse
    {
        public bool ReceiveDailyReports { get; set; }
        public bool ReceiveWeeklyReports { get; set; }
        public bool ReceiveMonthlyReports { get; set; }
    }
}

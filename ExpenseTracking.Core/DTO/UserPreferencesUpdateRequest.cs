using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

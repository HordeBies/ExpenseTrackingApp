﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracking.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public bool ReceiveDailyReports { get; set; }
        public bool ReceiveWeeklyReports { get; set; }
        public bool ReceiveMonthlyReports { get; set; }
    }
}

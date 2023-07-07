using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracking.Infrastructure.Initializers
{
    public class ApplicationDbInitializer
    {
        public Task Initialize()
        {
            return Task.CompletedTask; // TODO: Seed database here with default user, maybe some default categories, etc.
        }
    }
}

using ExpenseTracking.Domain.Entities;
using ExpenseTracking.Domain.RepositoryContracts;
using ExpenseTracking.Infrastructure.DatabaseContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracking.Infrastructure.Repositories
{
    public class UserRepository(ApplicationDbContext db): Repository<ApplicationUser>(db), IUserRepository
    {
    }
}

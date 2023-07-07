using ExpenseTracking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracking.Domain.RepositoryContracts
{
    public interface IUserRepository : IRepository<ApplicationUser>
    {
    }
}

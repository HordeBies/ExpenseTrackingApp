using ExpenseTracking.Domain.Entities;
using ExpenseTracking.Domain.RepositoryContracts;
using ExpenseTracking.Infrastructure.DatabaseContexts;

namespace ExpenseTracking.Infrastructure.Repositories
{
    public class UserRepository(ApplicationDbContext db) : Repository<ApplicationUser>(db), IUserRepository
    {
    }
}

using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTracking.Infrastructure.DatabaseContexts;
using ExpenseTracking.Domain.RepositoryContracts;

namespace ExpenseTracking.Infrastructure.Repositories
{
    public class UnitOfWork(ApplicationDbContext db) : IUnitOfWork
    {
        private IDbContextTransaction transaction;

        public void BeginTransaction()
        {
            transaction = db.Database.BeginTransaction();
        }

        public void Commit()
        {
            transaction?.Commit();
            transaction = null;
        }

        public void Rollback()
        {
            transaction?.Rollback();
            transaction = null;
        }

        public void Dispose()
        {
            transaction?.Dispose();
        }
        
    }

}

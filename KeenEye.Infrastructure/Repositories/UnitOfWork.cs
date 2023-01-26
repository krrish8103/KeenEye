using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KeenEye.Core.Interfaces;

namespace KeenEye.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContextClass _dbContext;
        public IProductRepository Products { get; }
        public IUserRepository Users { get; }

        public UnitOfWork(DbContextClass dbContext,
                            IProductRepository productRepository,
                            IUserRepository users)
        {
            _dbContext = dbContext;
            Products = productRepository;
            Users = users;
        }

        public int Save()
        {
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }

    }
}

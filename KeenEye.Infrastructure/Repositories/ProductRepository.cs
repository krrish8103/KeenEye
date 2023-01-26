using KeenEye.Core.Interfaces;
using KeenEye.Core.Models;

namespace KeenEye.Infrastructure.Repositories
{
    public class ProductRepository : GenericRepository<ProductDetails>, IProductRepository
    {
        public ProductRepository(DbContextClass dbContext) : base(dbContext)
        {

        }
    }
}

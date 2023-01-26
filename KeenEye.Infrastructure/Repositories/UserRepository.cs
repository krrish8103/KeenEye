using KeenEye.Core.Interfaces;
using KeenEye.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeenEye.Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(DbContextClass dbContext) : base(dbContext)
        {

        }
    }
}

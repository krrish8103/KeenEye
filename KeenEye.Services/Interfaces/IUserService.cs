using KeenEye.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeenEye.Services.Interfaces
{
    public interface IUserService
    {
        Task<bool> CreateUser(User user);

        Task<IEnumerable<User>> GetAllUsers();

        Task<User> GetUserById(int userId);

        Task<bool> UpdateUser(User user);

        Task<bool> DeleteUser(int userId);
    }
}

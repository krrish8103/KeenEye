using KeenEye.Core.Interfaces;
using KeenEye.Core.Models;
using KeenEye.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeenEye.Services
{
    public class UserService : IUserService
    {
        public IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateUser(User user)
        {
            if (user != null)
            {
                await _unitOfWork.Users.Add(user);

                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public async Task<bool> DeleteUser(int userId)
        {
            if (userId > 0)
            {
                var user = await _unitOfWork.Users.GetById(userId);
                if (user != null)
                {
                    _unitOfWork.Users.Delete(user);
                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            var userList = await _unitOfWork.Users.GetAll();
            return userList;
        }

        public async Task<User> GetUserById(int userId)
        {
            if (userId > 0)
            {
                var user = await _unitOfWork.Users.GetById(userId);
                if (user != null)
                {
                    return user;
                }
            }
            return null;
        }

        public async Task<bool> UpdateUser(User user)
        {
            if (user != null)
            {
                var userObj = await _unitOfWork.Users.GetById(user.Id);
                if (userObj != null)
                {
                    userObj.UserName = userObj.UserName;
                    userObj.Password = userObj.Password;
                    userObj.Email = userObj.Email;
                    userObj.LastLoginTime = userObj.LastLoginTime;

                    _unitOfWork.Users.Update(userObj);

                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }
    }
}

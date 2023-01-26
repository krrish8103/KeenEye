using KeenEye.Core.Models;
using KeenEye.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KeenEye.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Get the list of user
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetUserList()
        {
            var usersList = await _userService.GetAllUsers();
            if (usersList == null)
            {
                return NotFound();
            }
            return Ok(usersList);
        }

        /// <summary>
        /// Get user by id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserById(int userId)
        {
            var userDetails = await _userService.GetUserById(userId);

            if (userDetails != null)
            {
                return Ok(userDetails);
            }
            else
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Add a new user
        /// </summary>
        /// <param name="userDetails"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateUser(User userDetails)
        {
            var isUserCreated = await _userService.CreateUser(userDetails);

            if (isUserCreated)
            {
                return Ok(isUserCreated);
            }
            else
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Update the user
        /// </summary>
        /// <param name="userDetails"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateUser(User userDetails)
        {
            if (userDetails != null)
            {
                var isUserCreated = await _userService.UpdateUser(userDetails);
                if (isUserCreated)
                {
                    return Ok(isUserCreated);
                }
                return BadRequest();
            }
            else
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Delete user by id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            var isUserDeleted = await _userService.DeleteUser(userId);

            if (isUserDeleted)
            {
                return Ok(isUserDeleted);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}


using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DigitalWalletAPI.DTOs;
using DigitalWalletAPI.Models;
using DigitalWalletAPI.Services;
using System.Threading.Tasks;

namespace DigitalWalletAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateUser([FromBody] UserDTO userDto)
        {
            var result = await _userService.CreateUserAsync(userDto);
            if (result.Success)
            {
                return CreatedAtAction(nameof(GetUser), new { id = result.User.Id }, result.User);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpGet("{id}/balance")]
        [Authorize]
        public async Task<IActionResult> GetUserBalance(int id)
        {
            var balance = await _userService.GetUserBalanceAsync(id);
            if (balance == null)
            {
                return NotFound();
            }
            return Ok(new { Balance = balance });
        }
    }
}
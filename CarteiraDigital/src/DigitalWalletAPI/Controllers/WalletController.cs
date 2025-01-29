using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using DigitalWalletAPI.DTOs;
using DigitalWalletAPI.Services;

namespace DigitalWalletAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class WalletController : ControllerBase
    {
        private readonly WalletService _walletService;

        public WalletController(WalletService walletService)
        {
            _walletService = walletService;
        }

        [HttpGet("{userId}/balance")]
        public async Task<IActionResult> GetBalance(string userId)
        {
            var balance = await _walletService.GetBalanceAsync(userId);
            if (balance == null)
            {
                return NotFound();
            }
            return Ok(new WalletDTO { Balance = balance });
        }

        [HttpPost("{userId}/add-funds")]
        public async Task<IActionResult> AddFunds(string userId, [FromBody] decimal amount)
        {
            var result = await _walletService.AddFundsAsync(userId, amount);
            if (!result)
            {
                return BadRequest("Unable to add funds.");
            }
            return NoContent();
        }
    }
}
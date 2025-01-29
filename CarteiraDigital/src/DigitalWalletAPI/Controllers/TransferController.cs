using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalWalletAPI.DTOs;
using DigitalWalletAPI.Services;

namespace DigitalWalletAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TransferController : ControllerBase
    {
        private readonly TransferService _transferService;

        public TransferController(TransferService transferService)
        {
            _transferService = transferService;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateTransfer([FromBody] TransferDTO transferDto)
        {
            if (transferDto == null)
            {
                return BadRequest("Transfer data is required.");
            }

            var result = await _transferService.CreateTransferAsync(transferDto);
            if (result)
            {
                return Ok("Transfer created successfully.");
            }

            return BadRequest("Transfer creation failed.");
        }

        [HttpGet]
        [Route("list/{userId}")]
        public async Task<IActionResult> ListTransfers(string userId, DateTime? startDate = null, DateTime? endDate = null)
        {
            var transfers = await _transferService.ListTransfersAsync(userId, startDate, endDate);
            return Ok(transfers);
        }
    }
}
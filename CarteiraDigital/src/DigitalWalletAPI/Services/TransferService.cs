using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DigitalWalletAPI.Data;
using DigitalWalletAPI.Models;
using DigitalWalletAPI.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DigitalWalletAPI.Services
{
    public class TransferService
    {
        private readonly ApplicationDbContext _context;

        public TransferService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<TransferDTO> CreateTransferAsync(TransferDTO transferDto)
        {
            var transfer = new Transfer
            {
                FromUserId = transferDto.FromUserId,
                ToUserId = transferDto.ToUserId,
                Amount = transferDto.Amount,
                Date = DateTime.UtcNow
            };

            _context.Transfers.Add(transfer);
            await _context.SaveChangesAsync();

            return transferDto;
        }

        public async Task<List<TransferDTO>> GetTransfersByUserIdAsync(Guid userId, DateTime? startDate = null, DateTime? endDate = null)
        {
            var query = _context.Transfers.AsQueryable();

            query = query.Where(t => t.FromUserId == userId || t.ToUserId == userId);

            if (startDate.HasValue)
            {
                query = query.Where(t => t.Date >= startDate.Value);
            }

            if (endDate.HasValue)
            {
                query = query.Where(t => t.Date <= endDate.Value);
            }

            var transfers = await query.ToListAsync();

            return transfers.Select(t => new TransferDTO
            {
                FromUserId = t.FromUserId,
                ToUserId = t.ToUserId,
                Amount = t.Amount,
                Date = t.Date
            }).ToList();
        }
    }
}
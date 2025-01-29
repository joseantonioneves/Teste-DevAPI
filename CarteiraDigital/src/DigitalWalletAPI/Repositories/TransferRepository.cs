using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DigitalWalletAPI.Data;
using DigitalWalletAPI.Models;
using DigitalWalletAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DigitalWalletAPI.Repositories
{
    public class TransferRepository : ITransferRepository
    {
        private readonly ApplicationDbContext _context;

        public TransferRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Transfer> CreateTransferAsync(Transfer transfer)
        {
            await _context.Transfers.AddAsync(transfer);
            await _context.SaveChangesAsync();
            return transfer;
        }

        public async Task<List<Transfer>> GetTransfersByUserIdAsync(int userId, DateTime? startDate = null, DateTime? endDate = null)
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

            return await query.ToListAsync();
        }
    }
}
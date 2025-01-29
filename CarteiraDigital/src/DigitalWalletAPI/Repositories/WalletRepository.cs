using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalWalletAPI.Models;

namespace DigitalWalletAPI.Repositories
{
    public class WalletRepository : IWalletRepository
    {
        private readonly ApplicationDbContext _context;

        public WalletRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Wallet> GetWalletByUserIdAsync(int userId)
        {
            return await _context.Wallets.FindAsync(userId);
        }

        public async Task<Wallet> AddFundsAsync(int userId, decimal amount)
        {
            var wallet = await GetWalletByUserIdAsync(userId);
            if (wallet != null)
            {
                wallet.Balance += amount;
                await _context.SaveChangesAsync();
            }
            return wallet;
        }

        public async Task<IEnumerable<Wallet>> GetAllWalletsAsync()
        {
            return await _context.Wallets.ToListAsync();
        }
    }
}
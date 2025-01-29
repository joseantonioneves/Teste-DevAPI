using System.Threading.Tasks;
using DigitalWalletAPI.Models;
using DigitalWalletAPI.DTOs;
using DigitalWalletAPI.Repositories;

namespace DigitalWalletAPI.Services
{
    public class WalletService
    {
        private readonly IWalletRepository _walletRepository;

        public WalletService(IWalletRepository walletRepository)
        {
            _walletRepository = walletRepository;
        }

        public async Task<WalletDTO> GetWalletBalanceAsync(int userId)
        {
            var wallet = await _walletRepository.GetWalletByUserIdAsync(userId);
            return new WalletDTO { Balance = wallet.Balance };
        }

        public async Task<bool> AddFundsAsync(int userId, decimal amount)
        {
            var wallet = await _walletRepository.GetWalletByUserIdAsync(userId);
            wallet.Balance += amount;
            return await _walletRepository.UpdateWalletAsync(wallet);
        }
    }
}
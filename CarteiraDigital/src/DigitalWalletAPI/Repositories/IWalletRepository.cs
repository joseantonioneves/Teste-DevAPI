namespace DigitalWalletAPI.Repositories
{
    public interface IWalletRepository
    {
        Task<Wallet> GetWalletByUserIdAsync(int userId);
        Task<Wallet> AddFundsAsync(int userId, decimal amount);
        Task<bool> UpdateWalletAsync(Wallet wallet);
    }
}
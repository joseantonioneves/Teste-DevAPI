namespace DigitalWalletAPI.Repositories
{
    public interface ITransferRepository
    {
        Task<Transfer> CreateTransferAsync(Transfer transfer);
        Task<IEnumerable<Transfer>> GetTransfersByUserIdAsync(int userId, DateTime? startDate = null, DateTime? endDate = null);
    }
}
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using DigitalWalletAPI.Models;

namespace DigitalWalletAPI.Data
{
    public static class SeedData
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            // Check if any users exist
            if (context.Users.Any())
            {
                return;   // DB has been seeded
            }

            var users = new User[]
            {
                new User { Username = "user1", PasswordHash = "hashedpassword1" },
                new User { Username = "user2", PasswordHash = "hashedpassword2" }
            };

            context.Users.AddRange(users);
            context.SaveChanges();

            var wallets = new Wallet[]
            {
                new Wallet { UserId = users[0].Id, Balance = 100.00m },
                new Wallet { UserId = users[1].Id, Balance = 200.00m }
            };

            context.Wallets.AddRange(wallets);
            context.SaveChanges();

            var transfers = new Transfer[]
            {
                new Transfer { FromUserId = users[0].Id, ToUserId = users[1].Id, Amount = 50.00m, Date = DateTime.Now },
                new Transfer { FromUserId = users[1].Id, ToUserId = users[0].Id, Amount = 30.00m, Date = DateTime.Now }
            };

            context.Transfers.AddRange(transfers);
            context.SaveChanges();
        }
    }
}
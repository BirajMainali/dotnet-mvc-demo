using System;
using System.Threading.Tasks;
using System.Transactions;
using MvcDemo.Data;
using MvcDemo.Models;
using MvcDemo.Services.Interfaces;
using MvcDemo.ViewModel;

namespace MvcDemo.Services
{
    public class ClientServices : IClientServices

    {
        private readonly ApplicationDbContext _context;

        public ClientServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(ClientVm dto)
        {
            using var txn = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            var client = new Client
            {
                ClientName = dto.ClientName,
                Address = dto.Address.ToLower(),
                Product = dto.Product,
                RecDate = DateTime.Now,
                ClientDate = dto.ClientDate
            };
            await _context.Clients.AddAsync(client);
            await _context.SaveChangesAsync();
            txn.Complete();
        }
    }
}

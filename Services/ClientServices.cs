using System;
using System.Threading.Tasks;
using System.Transactions;
using MvcDemo.Data;
using MvcDemo.Dto;
using MvcDemo.Models;
using MvcDemo.Repository.Interfaces;
using MvcDemo.Services.Interfaces;
using MvcDemo.ViewModel;

namespace MvcDemo.Services
{
    public class ClientServices : IClientServices

    {
        private readonly IClientRepository _clientRepo;

        public ClientServices(IClientRepository clientRepo)
        {
            _clientRepo = clientRepo;
        }

        public async Task Create(ClientVm dto)
        {
            using var txn = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            var client = new Client
            {
                ClientName = dto.ClientName,
                Address = dto.Address,
                Product = dto.Product,
                RecDate = DateTime.Now,
                ClientDate = dto.ClientDate
            };
            client.ClientLogs.Add(new ClientLog()
            {
                Action = "Created",
                Client = client,
                Date = DateTime.Now,
                ActionBy = "Self"
            });
            await _clientRepo.Create(client);
            await _clientRepo.Flush();
            txn.Complete();
        }

        public async Task Update(Client client, ClientUpdateDto dto)
        {
            using var tx = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            client.Address = dto.Address;
            client.Product = dto.Product;
            client.ClientDate = dto.ClientDate;
            client.ClientName = dto.ClientName;
            client.ClientLogs.Add(new ClientLog()
            {
                Action = "Client updated. Name Updated",
                Client = client,
                Date = DateTime.Now,
                ActionBy = "Self"
            });
            _clientRepo.Update(client);
            await _clientRepo.Flush();
            tx.Complete();
        }

        public async Task Delete(Client client)
        {
            using var tx = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            await _clientRepo.Remove(client);
            await _clientRepo.Flush();
            tx.Complete();
        }
    }
}
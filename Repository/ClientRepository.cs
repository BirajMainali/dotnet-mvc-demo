using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcDemo.Data;
using MvcDemo.Models;
using MvcDemo.Repository.Interfaces;
using SQLitePCL;

namespace MvcDemo.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<Client> _dbSet;

        public ClientRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Clients;
        }

        public async Task<Client> Find(long id)
            => await _dbSet.FindAsync((int) id);

        public async Task<Client> FindOrThrow(long id)
            => (await Find(id)) ?? throw new Exception("Client not found");

        public async Task<List<Client>> GetAll()
            => await _dbSet.ToListAsync();

        public IQueryable<Client> GetQueryable() => _dbSet.AsQueryable();

        public async Task Create(Client client) => await _dbSet.AddAsync(client);

        public void Update(Client client)
            => _context.Update(client);

        public async Task Flush() => await _context.SaveChangesAsync();

        public async Task Remove(Client client) => _context.Clients.Remove(client);
    }
}
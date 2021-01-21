using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcDemo.Models;

namespace MvcDemo.Repository.Interfaces
{
    public interface IClientRepository
    {
        Task<Client> Find(long id);
        Task<Client> FindOrThrow(long id);
        Task<List<Client>> GetAll();
        IQueryable<Client> GetQueryable();
        Task Create(Client client);
        void Update(Client client);
        Task Flush();
        Task Remove(Client client);
    }
}
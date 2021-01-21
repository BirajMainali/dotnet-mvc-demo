using System.Threading.Tasks;
using MvcDemo.Dto;
using MvcDemo.Models;
using MvcDemo.ViewModel;

namespace MvcDemo.Services.Interfaces
{
    public interface IClientServices
    {
        Task Create(ClientVm dto);
        Task Update(Client client, ClientUpdateDto dto);
        Task Delete(Client client);
    }
}
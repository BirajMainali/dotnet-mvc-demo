using System.Threading.Tasks;
using MvcDemo.Dto;
using MvcDemo.Models;
using MvcDemo.ViewModel;

namespace MvcDemo.Services.Interfaces
{
    public interface IClientServices
    {
        Task Create(ClientVm vm);
        Task Update(Client client, ClientUpdateDto dto);
        Task Delete(Client client);
    }
}
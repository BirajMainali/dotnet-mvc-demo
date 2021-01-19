using System.Threading.Tasks;
using MvcDemo.ViewModel;

namespace MvcDemo.Services.Interfaces
{
    public interface IClientServices
    {
        Task Create(ClientVm dto);
    }
}

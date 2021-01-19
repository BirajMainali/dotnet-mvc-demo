using System;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.AspNetCore.Mvc;
using MvcDemo.Services.Interfaces;
using MvcDemo.ViewModel;

namespace MvcDemo.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientServices _clientServices;

        public ClientController(IClientServices clientServices)
        {
            _clientServices = clientServices;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var client = new ClientVm();
            return View(client);
        }
        public async Task<IActionResult> New(ClientVm clientVm)
        {
            try
            {
                throw new AppDomainUnloadedException();
                using (var txn = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    await _clientServices.Create(clientVm);
                    txn.Complete();
                }
             
                return View(clientVm);
            }
            catch (Exception ex)
            {
                TempData["exception"] = ex.Message;
                return View(clientVm); 
            }
            
        }
        [HttpPost]
        public IActionResult New()
        {
            return View();
        }
    }
}

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

        [HttpPost]
        public async Task<IActionResult> New(ClientVm clientVm)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return View(clientVm);
                }
                await _clientServices.Create(clientVm);          
                TempData["success"] = "Client Created";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["exception"] = ex.Message;
                return View(clientVm); 
            }
            
        }
        public IActionResult New()
        {
            return View(new ClientVm());
        }
    }
}

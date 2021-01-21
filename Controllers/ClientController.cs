using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MvcDemo.Data;
using MvcDemo.Services.Interfaces;
using MvcDemo.ViewModel;

namespace MvcDemo.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientServices _clientServices;
        private readonly ApplicationDbContext _context;

        public ClientController(IClientServices clientServices, ApplicationDbContext context)
        {
            _clientServices = clientServices;
            _context = context;
        }
        
        public IActionResult Index(SearchVm searchVm)
        {
            try
            {
                var clients = _context.Clients.ToList();
                if (!string.IsNullOrEmpty(searchVm.ClientAddress) || !string.IsNullOrWhiteSpace(searchVm.ClientAddress))
                {
                    clients = _context.Clients.Where(x => x.Address.ToLower().Contains(searchVm.ClientAddress.ToLower())).ToList();
                }
                return View(clients);
            }
            catch (Exception ex)
            {
                TempData["exception"] = ex.Message;
                return View();

            }
        }

        [HttpPost]
        public async Task<IActionResult> New(ClientVm clientVm)
        {
            try
            {
                if (!ModelState.IsValid) return View(clientVm);
                await _clientServices.Create(clientVm);
                TempData["success"] = "Successfully client has been Added";
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
            try
            {
                return View(new ClientVm());
            }
            catch (Exception ex)
            {
                TempData["exception"] = ex.Message;
                return View(new ClientVm());
            }
        }
    }
}

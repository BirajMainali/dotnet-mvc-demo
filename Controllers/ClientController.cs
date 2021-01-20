using System;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
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
        [HttpGet]
        public IActionResult Index()
        {
            // var clients = _context.Clients.Where(x => x.Address=="jhapa").ToList();
            var clients = _context.Clients.ToList();
            return View(clients);
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
            return View(new ClientVm());
        }
    }
}

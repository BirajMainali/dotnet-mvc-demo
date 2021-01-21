using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcDemo.Data;
using MvcDemo.Dto;
using MvcDemo.Models;
using MvcDemo.Repository.Interfaces;
using MvcDemo.Services.Interfaces;
using MvcDemo.ViewModel;

namespace MvcDemo.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientServices _clientServices;
        private readonly IClientRepository _clientRepo;

        public ClientController(IClientServices clientServices, IClientRepository clientRepo)
        {
            _clientServices = clientServices;
            _clientRepo = clientRepo;
        }

        public async Task<IActionResult> Index(SearchVm searchVm)
        {
            try
            {
                var clientQueryable = _clientRepo.GetQueryable();
                if (!string.IsNullOrEmpty(searchVm.ClientAddress) || !string.IsNullOrWhiteSpace(searchVm.ClientAddress))
                {
                    clientQueryable = clientQueryable.Where(
                        x => x.Address.ToLower().Contains(searchVm.ClientAddress.ToLower()));
                }

                return View(await clientQueryable.ToListAsync());
            }
            catch (Exception ex)
            {
                TempData["exception"] = ex.Message;
                return View();
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

        public async Task<IActionResult> Update(long id)
        {
            try
            {
                var client = await _clientRepo.FindOrThrow(id);
                var clientEditVm = new ClientUpdateVm()
                {
                    Client = client,
                    Address = client.Address,
                    Product = client.Product,
                    ClientDate = client.ClientDate,
                    ClientName = client.ClientName
                };
                return View(clientEditVm);
            }
            catch (Exception ex)
            {
                TempData["exception"] = ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(long id, ClientUpdateVm vm)
        {
            try
            {
                var client = await _clientRepo.FindOrThrow(id);
                if (!ModelState.IsValid)
                {
                    vm.Client = client;
                    return View(vm); //Render Form
                }

                var updateDto = new ClientUpdateDto()
                {
                    Address = vm.Address,
                    Product = vm.Product,
                    ClientDate = vm.ClientDate,
                    ClientName = vm.ClientName
                };
                await _clientServices.Update(client, updateDto);
                TempData["success"] = $"Client #{id} updated";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["exception"] = ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
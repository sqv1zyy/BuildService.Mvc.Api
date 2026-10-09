using BuildService.Mvc.Api.Domain.Entities;
using BuildService.Mvc.Api.Domain.Repositories;
using BuildService.Mvc.Api.Infrastructure;
using BuildService.Mvc.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace BuildService.Mvc.Api.Controllers
{
    public class ServicesController : Controller
    {
        private readonly DataManager _dataManager;

        public ServicesController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Service> list = await _dataManager.Services.GetServicesAsync();

            IEnumerable<ServiceDTO> listDTO = HelperDTO.TransformServices(list);

            return View(listDTO);
        }
    }
}

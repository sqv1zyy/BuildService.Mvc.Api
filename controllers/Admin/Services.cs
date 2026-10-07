using BuildService.Mvc.Api.Domain.Entities;
using Microsoft.AspNetCore.Mvc;


namespace BuildService.Mvc.Api.Controllers.Admin
{
    public partial class AdminController : Controller
    {
        public async Task<IActionResult> ServicesEdit(int id)
        {
            Service? entity = id == default ? new Service() : await _dataManager.Services.GetServicesByIdAsync(id);
            ViewBag.ServiceCategories = await _dataManager.ServicesCategories.GetServiceCategoriesAsync();
            return View(entity);
        }

        [HttpPost]
        public async Task<IActionResult> ServicesEdit(Service entity, IFormFile? titleImageFile)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ServiceCategories = await _dataManager.ServicesCategories.GetServiceCategoriesAsync();
                return View(entity);
            }

            if (titleImageFile != null)
            {
                entity.Photo = titleImageFile.FileName;
                await SaveImg(titleImageFile);
            }

            await _dataManager.Services.SaveServicesAsync(entity);

            return RedirectToAction("Index");
        }
        
        [HttpPost]
        public async Task<IActionResult> ServiceDelete(int id)
        {
            await _dataManager.Services.DeleteServicesAsync(id);
            return RedirectToAction("Index");
        }


    }
}

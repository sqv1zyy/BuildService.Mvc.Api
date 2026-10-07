using BuildService.Mvc.Api.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BuildService.Mvc.Api.Controllers.Admin
{
    public partial class AdminController : Controller
    {
        public async Task<IActionResult> ServiceCategoriesEdit(int id)
        {
            ServiceCategory? entity = id == default
                ? new ServiceCategory()
                : await _dataManager
                .ServicesCategories
                .GetServiceCategoriesByIdAsync(id);
            return View(entity);
        }

        [HttpPost]
        public async Task<IActionResult> ServiceCategoriesEdit(ServiceCategory entity)
        {
            if (!ModelState.IsValid)
            {
                return View(entity);
            }

            await _dataManager.ServicesCategories.SaveServiceCategoryAsync(entity);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> ServiceCategoriesDelete(int id)
        {
            await _dataManager.ServicesCategories.DeleteServiceCategoryAsync(id);
            return RedirectToAction("Index");
        }
    }
}
using BuildService.Mvc.Api.Domain.Entities;
using BuildService.Mvc.Api.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BuildService.Mvc.Api.Models.Components.Menu
{
    public class MenuViewComponent : ViewComponent
    {
        private readonly DataManager _dataManager;
        
        public MenuViewComponent(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            IEnumerable<Service> list = await _dataManager.Services.GetServicesAsync();

            return await Task.FromResult((IViewComponentResult) View("Default", list));
        }
    }
}

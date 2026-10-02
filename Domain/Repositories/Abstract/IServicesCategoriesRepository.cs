using BuildService.Mvc.Api.Domain.Entities;
namespace BuildService.Mvc.Api.Domain.Repositories.Abstract
{
    public interface IServicesCategoriesRepository
    {
        Task<IEnumerable<ServiceCategory>> GetServiceCategoriesAsync();
        Task<ServiceCategory> GetServiceCategoriesByIdAsync(int id);
        Task SaveServiceCategoryAsync(ServiceCategory entity);
        Task DeleteServiceCategoryAsync(int id);

    }
}

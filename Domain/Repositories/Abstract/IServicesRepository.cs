using BuildService.Mvc.Api.Domain.Entities;

namespace BuildService.Mvc.Api.Domain.Repositories.Abstract
{
    public interface IServicesRepository
    {
        Task<IEnumerable<Service>> GetServicesAsync();

        Task<Service?> GetServicesByIdAsync(int id);

        Task SaveServicesAsync(Service entity);

        Task DeleteServicesAsync(int id);
    }
}
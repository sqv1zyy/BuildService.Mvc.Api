using BuildService.Mvc.Api.Domain.Repositories.Abstract;

namespace BuildService.Mvc.Api.Domain.Repositories
{
    public class DataManager
    {
        public IServicesCategoriesRepository ServicesCategories { get; set; }
        public IServicesRepository Services {  get; set; }
        public DataManager(IServicesCategoriesRepository servicesCategoriesRepository,
            IServicesRepository servicesRepository)
        {
            ServicesCategories = servicesCategoriesRepository;
            Services = servicesRepository;
        }
    }
}

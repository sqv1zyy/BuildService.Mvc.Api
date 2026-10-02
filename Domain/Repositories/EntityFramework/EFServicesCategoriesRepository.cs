using BuildService.Mvc.Api.Domain.Entities;
using BuildService.Mvc.Api.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace BuildService.Mvc.Api.Domain.Repositories.EntityFramework
{
    public class EFServicesCategoriesRepository : IServicesCategoriesRepository
    {
        private readonly AppDbContext _contex;

        public EFServicesCategoriesRepository(AppDbContext contex)
        {
            _contex = contex;
        }

        public async Task<IEnumerable<ServiceCategory>> GetServiceCategoriesAsync()
        {
            return await _contex.ServiceCategories
                .Include(x => x.Services).ToListAsync();
        }

        public async Task<ServiceCategory?> GetServiceCategoriesByIdAsync(int id)
        {
            return await _contex.ServiceCategories.Include(x => x.Services)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task SaveServiceCategoryAsync(ServiceCategory entity)
        {
            _contex.Entry(entity).State = entity.Id == default 
                ? EntityState.Added : EntityState.Modified;
            await _contex.SaveChangesAsync();
        }

        public async Task DeleteServiceCategoryAsync(int id)
        {
            _contex.Entry(new ServiceCategory() { Id = id })
                .State = EntityState.Deleted;
            await _contex.SaveChangesAsync();
        }
        
    }
}

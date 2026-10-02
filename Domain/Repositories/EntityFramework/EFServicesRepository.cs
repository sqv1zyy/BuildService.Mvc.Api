using BuildService.Mvc.Api.Domain;
using BuildService.Mvc.Api.Domain.Entities;
using BuildService.Mvc.Api.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace BuildService.Mvc.Api.Domain.Repositories.EntityFramework
{
    public class EFServicesRepository : IServicesRepository
    {
        private readonly AppDbContext _context;

        public EFServicesRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Service>> GetServicesAsync()
        {
            return await _context.Services
                .Include(x => x.ServiceCategory)
                .ToListAsync();
        }

        public async Task<Service?> GetServicesByIdAsync(int id)
        {
            return await _context.Services
                .Include(x => x.ServiceCategory)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task SaveServicesAsync(Service entity)
        {
            _context.Entry(entity).State = entity.Id == default
                ? EntityState.Added
                : EntityState.Modified;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteServicesAsync(int id)
        {
            _context.Entry(new Service { Id = id }).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}
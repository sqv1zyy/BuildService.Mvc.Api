
namespace BuildService.Mvc.Api.Domain.Entities;
public class ServiceCategory : EntityBase
{
    //Связь услуги - категории : 1 к N
    public ICollection<Service>? Services { get; set; } 
}

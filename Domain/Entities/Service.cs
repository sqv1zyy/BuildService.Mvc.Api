using BuildService.Mvc.Api.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace BuildService.Mvc.Api.Domain.Entities
{
    public class Service : EntityBase
    {
        [Display (Name = "Выбери уровень услуги")]
        public int? ServiceCategoryId { get; set; }
        public ServiceCategory? ServiceCategory { get; set; }

        [Display(Name ="Краткое описание")]
        [MaxLength (3_000)]
        public string? DescriptionShort { get; set; }

        [Display(Name = "Описание")]
        [MaxLength(100_000)]
        public string? Description {  get; set; }

        [Display(Name = "Титульное изображение")]
        public string? Photo {  get; set; }

        [Display(Name = "Тип услуги")]
        public ServiceTypeEnum Type {  get; set; }
    }
}

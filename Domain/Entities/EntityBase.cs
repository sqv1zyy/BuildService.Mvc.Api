using System.ComponentModel.DataAnnotations;

namespace BuildService.Mvc.Api.Domain.Entities
{
    public abstract class EntityBase
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле название не может быть пустым !")]
        [Display(Name = "Название")]
        [MaxLength(256)]
        public string? Title { get; set; }

    }
}

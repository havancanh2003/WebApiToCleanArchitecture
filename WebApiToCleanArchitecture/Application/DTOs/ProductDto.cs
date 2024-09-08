using System.ComponentModel.DataAnnotations;

namespace WebApiToCleanArchitecture.Application.DTOs
{
    public class ProductDto
    {
        public Guid? Id { get; set; }

        [Required(ErrorMessage = "Không được để trống")]
        public string Name { get; set; } = string.Empty!;
        [Required(ErrorMessage = "Không được để trống")]
        public decimal Price { get; set; } = decimal.Zero!;
        public string? Description { get; set; }
    }
}

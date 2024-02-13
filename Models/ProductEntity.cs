using System.ComponentModel.DataAnnotations;

namespace WebApiBeta.Models
{
    public class ProductEntity
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public decimal Price { get; set; }

    }
}

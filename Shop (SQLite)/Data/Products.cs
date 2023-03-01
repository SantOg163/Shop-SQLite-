using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop__SQLite_.Data
{
    public class Products
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Price { get; set; }
        [Required, ForeignKey("Brands")]
        public int BrandId { get; set; }
        [Required,ForeignKey("Genders")]
        public int GenderId { get; set; }
        [Required, ForeignKey("Types")]
        public int CategoryId { get; set; }
        [Required, ForeignKey("Colors")]
        public int ColorId { get; set; }
        public string Description { get; set; }

    }
}

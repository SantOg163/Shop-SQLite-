using System.ComponentModel.DataAnnotations;

namespace Shop__SQLite_.Data
{
    public class Brands
    {
        [Key]
        public int BrandId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}

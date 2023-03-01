using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop__SQLite_.Data
{
    public class ProductSize
    {
        [Key]
        public int ProductSizeId { get; set; }
        [Required, ForeignKey("Products")]
        public int ProductId { get; set; }
        [Required, ForeignKey("Sizes")]
        public int SizeId { get; set; }
        public int Count { get; set; }

    }
}

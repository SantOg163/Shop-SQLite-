using System.ComponentModel.DataAnnotations;

namespace Shop__SQLite_.Data
{
    public class Categories
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}

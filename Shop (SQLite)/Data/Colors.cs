using System.ComponentModel.DataAnnotations;

namespace Shop__SQLite_.Data
{
    public class Colors
    {
        [Key]
        public int ColorId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}

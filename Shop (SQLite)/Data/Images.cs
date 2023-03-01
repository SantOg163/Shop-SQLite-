using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shop__SQLite_.Data
{
    public class Images
    {
        [Key]
        public int ImageId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required,ForeignKey("Products")]
        public int ProductId { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}

using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Shop__SQLite_.Data;
using System.ComponentModel.DataAnnotations;

namespace Shop.Models
{
    public class Input
    {
        [Required(ErrorMessage = "обязательное поле")]
        public string Brand { get; set; }
        [Required(ErrorMessage = "обязательное поле")]
        public string minSize { get; set; }
        [Required(ErrorMessage = "обязательное поле")]
        public string maxSize { get; set; }
        [Required(ErrorMessage = "обязательное поле")]
        public int countSize { get; set; }
        [Required(ErrorMessage = "обязательное поле")]
        public string Name { get; set; }
        [Required(ErrorMessage = "обязательное поле")]
        public int Price { get; set; }
        [Required(ErrorMessage = "обязательное поле")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "обязательное поле")]
        public string Category { get; set; }
        [Required(ErrorMessage = "обязательное поле")]
        public string Color { get; set; }
        [ ValidateNever]
        public List<Images> Images { get; set; } = new List<Images>() { new Images(), new Images(), new Images(), new Images(), new Images() };
        [Required(ErrorMessage = "обязательное поле")]
        public string Description { get; set; } = "";

    }
}

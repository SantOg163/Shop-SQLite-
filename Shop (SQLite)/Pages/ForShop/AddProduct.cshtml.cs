using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop__SQLite_.Data;
using Shop__SQLite_.Services;
using Shop.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Shop__SQLite_.Pages.ForShop
{

    public class AddProductModel : PageModel
    {
        [BindProperty]
        public Input input { get; set; } = new Input();
        public List<Categories> Categories { get; set; }
        public List<Brands> Brands { get; set; }
        public List<Genders> Genders { get; set; }
        public List<Colors> Colors { get; set; }
        public List<Sizes> Sizes { get; set; }
        private readonly Service _service;
        private readonly ImageService _imageService;
        public AddProductModel(Service service, ImageService imageService)
        {
            _service = service;
            _imageService = imageService;
            Categories = _service.GetCategoriesAsync().Result;
            Genders = _service.GetGendersAsync().Result;
            Colors = _service.GetColorsAsync().Result;
            Sizes = _service.GetSizesAsync().Result;
            Brands = _service.GetBrandsAsync().Result;
        }
        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPost()
        {

            if (ModelState.IsValid)
            {
                
                int maxSizeId = Sizes.Where(s => s.Name == input.maxSize).Select(s => s.SizeId).FirstOrDefault();
                int minSizeId = Sizes.Where(s => s.Name == input.minSize).Select(s => s.SizeId).FirstOrDefault();
                int GenderId = Genders.Where(g => g.Name == input.Gender).Select(g => g.GenderId).FirstOrDefault();
                int ColorId = Colors.Where(c => c.Name == input.Color).Select(c => c.ColorId).FirstOrDefault();
                int CategoryId = Categories.Where(c => c.Name == input.Category).Select(c => c.CategoryId).FirstOrDefault();
                int BrandId = Brands.Where(b => b.Name == input.Brand).Select(s => s.BrandId).FirstOrDefault();
                
                if (maxSizeId == 0)
                    ModelState.AddModelError(string.Empty, "Максимальный размер не найден");
                if (minSizeId == 0)
                    ModelState.AddModelError(string.Empty, "Минимальный размер не найден");
                if (GenderId == 0)
                    ModelState.AddModelError(string.Empty, "Пол не найден");
                if (ColorId == 0)
                    ModelState.AddModelError(string.Empty, "Цвет не найден");
                if (CategoryId == 0)
                    ModelState.AddModelError(string.Empty, "Категория не найдена");
                if (BrandId == 0)
                    ModelState.AddModelError(string.Empty, "Бренд не найдена");
                if (ModelState.IsValid == false)
                {
                    for (int i = input.Images.Count; i < 5; i++)
                        input.Images.Add(new Images());
                    return Page();
                }

                int ProductId = _service.GetProductsAsync().Result.LastOrDefault(new Products()).ProductId + 1;
                int ProductSizeId = _service.GetProductSizeAsync().Result.LastOrDefault(new ProductSize()).ProductSizeId + 1;
                int ImageId = _service.GetImagesAsync().Result.LastOrDefault(new Images()).ImageId + 1;

                Products newProduct = new Products 
                {
                    ProductId = ProductId,
                    BrandId = BrandId,
                    CategoryId = CategoryId,
                    ColorId = ColorId,
                    GenderId = GenderId,
                    Name = input.Name,
                    Price = input.Price,
                    Description = input.Description 
                };

                _service.AddProduct(newProduct);
                for (int i = 0; i < input.Images.Count; i++)
                {
                    input.Images[i].ImageId = ImageId + i;
                    input.Images[i].ProductId = ProductId;
                    await _imageService.AddImage(input.Images[i]);
                }

                for (int i = minSizeId, id = 0; i <= maxSizeId; i++, id++)
                {
                    ProductSize product = new ProductSize { ProductSizeId = ProductSizeId + id, ProductId = newProduct.ProductId, SizeId = i, Count = input.countSize };
                    await _service.AddProductSize(product);
                }

                return RedirectToPage("/Index");
            }
            else
            {
                for (int i = input.Images.Count; i < 5; i++)
                    input.Images.Add(new Images());

                return Page();
            }
        }
    }
}
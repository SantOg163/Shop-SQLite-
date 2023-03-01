using Microsoft.AspNetCore.Mvc.RazorPages;
using Shop__SQLite_.Data;
using Shop__SQLite_.Models;
using Shop__SQLite_.Services;

namespace Shop__SQLite_.Pages.ForShop
{
    public class ProductsModel : PageModel
    {
        public string Info { get; set; }
        public List<Categories> Categories { get; set; }
        public List<Colors> Colors { get; set; }
        public List<Sizes> Sizes { get; set; }
        public List<Brands> Brands { get; set; }
        public List<Images> Images { get; set; }
        public List<Card> Cards { get; set; } = new List<Card> { };
        private readonly Service _service;
        public ProductsModel(Service service)
        {
            _service = service;
        }
        public async void OnGet(string gender)
        {
            //Ошибка CS1061  "List<string>" не содержит определения "GetAwaiter",
            //и не удалось найти доступный метод расширения "GetAwaiter",
            //принимающий тип "List<string>" в качестве первого аргумента(возможно, пропущена директива using или ссылка на сборку).
            //Categories = await _service.GetCategoriesAsync().Result;
            Categories = _service.GetCategoriesAsync().Result;
            Colors = _service.GetColorsAsync().Result;
            Sizes = _service.GetSizesAsync().Result;
            Brands = _service.GetBrandsAsync().Result;
            Images = _service.GetImagesAsync().Result;
            if (gender == "men")
            {
                Info = "Мужская одежда и обувь";
                foreach (Products product in _service.GetProductsAsync().Result.Where(p => p.GenderId == 1 || p.GenderId == 3))
                {
                    Cards.Add(new Card()
                    {
                        Id = product.ProductId,
                        Name = product.Name,
                        Price = product.Price,
                        Brand = Brands.Where(b => b.BrandId == product.BrandId).FirstOrDefault(new Brands()).Name,
                        Category = Categories.Where(c => c.CategoryId == product.CategoryId).FirstOrDefault(new Categories()).Name,
                        imgSrc = Images.Where(c => c.ProductId == product.ProductId).FirstOrDefault(new Images()).Name
                    });
                }

            }
            if (gender == "women")
            {
                Info = "Женская одежда и обувь";
                foreach (Products product in _service.GetProductsAsync().Result.Where(p => p.GenderId == 2 || p.GenderId == 3))
                {
                    Cards.Add(new Card()
                    {
                        Id = product.ProductId,
                        Name = product.Name,
                        Price = product.Price,
                        Brand = Brands.Where(b => b.BrandId == product.BrandId).FirstOrDefault(new Brands()).Name,
                        Category = Categories.Where(c => c.CategoryId == product.CategoryId).FirstOrDefault(new Categories()).Name,
                        imgSrc = Images.Where(c => c.ProductId == product.ProductId).FirstOrDefault(new Images()).Name
                    });
                }

            }

        }

    }
}

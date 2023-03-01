using Microsoft.EntityFrameworkCore;
using Shop__SQLite_.Data;
using Shop__SQLite_.Models;

namespace Shop__SQLite_.Services
{
    public class Service
    {
        private readonly ApplicationDbContext _context;
        public Service(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Categories>> GetCategoriesAsync() => await _context.Categories.ToListAsync();
        public async Task<Categories> GetCategory(int id) => await _context.Categories.Where(c => c.CategoryId == id).FirstOrDefaultAsync();

        public async Task<List<Genders>> GetGendersAsync() => await _context.Genders.ToListAsync();

        public async Task<List<ProductSize>> GetProductSizeAsync() => await _context.ProductSize.ToListAsync();
        public async Task<List<Sizes>> GetRemainingSizes(int id) => await GetSize(_context.ProductSize.Where(p => p.ProductId == id).Select(p => p.SizeId).ToList());

        public async Task<List<Sizes>> GetSizesAsync() => await _context.Sizes.ToListAsync();
        public async Task<List<Sizes>> GetSize(List<int> id) => await _context.Sizes.Where(s => id.Contains(s.SizeId)).ToListAsync();

        public async Task<List<Images>> GetImagesAsync() => await _context.Images.ToListAsync();
        public async Task<List<Images>> GetImages(int id) => await _context.Images.Where(i => i.ProductId == id).ToListAsync();


        public async Task<List<Colors>> GetColorsAsync() => await _context.Colors.ToListAsync();
        public async Task<Colors> GetColor(int id) => await _context.Colors.Where(i => i.ColorId == id).FirstOrDefaultAsync();


        public async Task<List<Brands>> GetBrandsAsync() => await _context.Brands.ToListAsync();
        public async Task<Brands> GetBrand(int id) => await _context.Brands.Where(i => i.BrandId == id).FirstOrDefaultAsync();

        public async Task<List<Products>> GetProductsAsync() => await _context.Products.ToListAsync();
        public async Task<Products> GetProductAsync(string name) => _context.Products.ToList().Where(p => p.Name == name).FirstOrDefault(new Products());
        public async Task<ViewProduct> GetProductView(string name)
        {
            Products product = GetProductAsync(name.Replace("-", " ")).Result;
            Categories category = GetCategory(product.CategoryId).Result;
            List<Sizes> sizes = GetRemainingSizes(product.ProductId).Result;
            List<Images> images = GetImages(product.ProductId).Result;
            Brands brand = GetBrand(product.BrandId).Result;
            if (product != null && category != null && sizes != null && images != null && brand != null)
                return new ViewProduct()
                {
                    Name = name,
                    Description = product.Description,
                    Price = product.Price,
                    Category = category.Name,
                    SizesList = sizes,
                    ImagesList = images,
                    Brand = brand.Name
                };
            return new ViewProduct();

        }

        public void AddProduct(Products product)
        {
            try
            {
                _context.Products.Add(product);
                _context.SaveChanges();
            }
            catch
            {
                throw new Exception();
            }
        }
        public async Task AddProductSize(ProductSize product)
        {
            _context.ProductSize.Add(product);
            await _context.SaveChangesAsync();
        }

    }
}
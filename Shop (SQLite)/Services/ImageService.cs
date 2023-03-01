using Microsoft.AspNetCore.Mvc;
using Shop__SQLite_.Data;

namespace Shop__SQLite_.Services
{
    public class ImageService
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;
        public ImageService(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }
        public async Task AddImage([Bind("ImageId,Name,ProductId,ImageFile")] Images image)
        {
            string wwwRootPath = _hostEnvironment.WebRootPath;
            string fileName = Path.GetFileNameWithoutExtension(image.ImageFile.FileName);
            string extension = Path.GetExtension(image.ImageFile.FileName);
            image.Name = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            try
            {
                _context.Images.Add(image);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
            string path = Path.Combine(wwwRootPath + "/Img/Clothes", fileName);
            using(FileStream fs = new FileStream(path, FileMode.Create))
            {
                await image.ImageFile.CopyToAsync(fs);
            }           
        }        
    }
}

using Shop__SQLite_.Data;

namespace Shop__SQLite_.Models
{
    public class ViewProduct
    {
        public string Brand { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public List<Sizes> SizesList { get; set; }= new List<Sizes>();
        public int Price { get; set; }
        public List<Images> ImagesList { get; set; } = new List<Images>();
        public string Description { get; set; }
    }
}

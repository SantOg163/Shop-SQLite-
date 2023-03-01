using System.ComponentModel.DataAnnotations.Schema;

namespace Shop__SQLite_.Data
{
    public class Orders
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        [ForeignKey("ProductSize")]
        public int ProductSizeId { get; set; }
        public string Address { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime DeliveryDay {get;set;}
        public bool Delivered { get; set; }
    }
}

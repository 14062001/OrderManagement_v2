using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderManagement_v2.Models
{
    public class Product
    {
        [Key]
        public int Product_id { get; set; }
    
        public string Product_name { get; set; }
        public string Product_details { get; set; }
      
        public int Product_price { get; set; }
        [ForeignKey("Order_id")]
        public int? Order_id { get; set; }
        [NotMapped]
        public virtual Order order { get; set; }
    }
}

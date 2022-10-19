using System;
using System.ComponentModel.DataAnnotations;

namespace OrderManagement_v2.Models
{
    public class Order
    {
        [Key]
        public int Order_id { get; set; }
        public string status { get; set; }
        public string Order_details { get; set; }
        public int quantity { get; set; }
        [DataType(DataType.Date)]
        public DateTime Order_date { get; set; }
        [DataType(DataType.Date)]
        public DateTime Shipment_date { get; set; }

        public string Payment_method { get; set; }
        public int Total_Price { get; set; }

    }
}

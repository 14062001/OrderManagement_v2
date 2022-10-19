using System.ComponentModel.DataAnnotations;

namespace OrderManagement_v2.Models
{
    public class Customer
    {
        [Required]
        [Key]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string  Password{ get; set; }
    }
}

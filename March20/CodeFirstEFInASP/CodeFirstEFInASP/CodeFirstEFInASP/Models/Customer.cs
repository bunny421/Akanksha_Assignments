using System.ComponentModel.DataAnnotations;

namespace CodeFirstEFInASP.Models
{
    public class Customer
    {
        public int CustomerID {  get; set; }

        [Required]
        public string CustomerName { get; set; }
        public ICollection<Product> Products {  get; set; }

    }
}

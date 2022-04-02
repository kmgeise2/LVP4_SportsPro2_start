using System.Collections.Generic;

namespace LVP4_SportsPro2_start.Models
{
    public class RegistrationViewModel
    {
        public int CustomerID { get; set; }
        public int ProductID { get; set; }
        public Customer Customer { get; set; }
        public IEnumerable<Registration> Registrations { get; set; }
        public IEnumerable<Customer> Customers { get; set; }
        public IEnumerable<Product> Products { get; set; }

    }
}

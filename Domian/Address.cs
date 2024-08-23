using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domian
{
    [Table("Address")]
    public class Address
    {
        public int Id { get; set; }

        [MaxLength(100), MinLength(3)]
        public string City { get; set; }

        [MaxLength(50), MinLength(3)]
        public string Region { get; set; }

        [MaxLength(10), MinLength(5)]
        public string Country { get; set; }

        [MaxLength(100), MinLength(5)]
        public string Email { get; set; }

        public virtual ICollection<UserAddress>? UserAddresses { get; set; }
        public virtual ICollection<Order>? Orders { get; set; }

        public Address(string city, string region, string country)
        {
            City = city;
            Region = region;
            Country = country;
            UserAddresses = new List<UserAddress>();
            Orders = new List<Order>();
        }

        public Address() : this(null!, null!, null!)
        {
        }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Dtos.Addresses
{
    public class AddressMinimalDTO
    {
        public int Id { get; set; }
      
        [MaxLength(100), MinLength(3)]
        public string City { get; set; }
        [MaxLength(50), MinLength(3)]
        public string Region { get; set; }
       
        [MaxLength(100), MinLength(5)]
        public string Country { get; set; }

        [MaxLength(100), MinLength(5)]
        public string Email { get; set; }

        public string Fanme { get; set; }

        public string Lanme { get; set; }

        public string Phone { get; set; }

        public AddressMinimalDTO():this(null!,null!,null!,null!,null!,null!,null!)
        {
            
        }

        public AddressMinimalDTO( string city, string region, string country,string e,string f , string l , string p)
        {
            City = city;
            Region = region;
            Country = country;
            Email = e;
            Fanme = f;
            Lanme = l;
            Phone = p;
        }
    }
}

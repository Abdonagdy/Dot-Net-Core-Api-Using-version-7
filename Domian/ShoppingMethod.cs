using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domian
{
    [Table("ShoppingMethod")]
    public class ShoppingMethod
    {
        public int Id { get; set; }
        [MinLength(3),MaxLength(100)]
        public string? Name { get; set; }
        public decimal? Price { get; set; }

        public string? Description { get; set; }

        public string? Token { get; set; }


        public string? BaseUrl { get; set; }



        public string? CallBackURL { get; set; }

        //relation with Order
        public IEnumerable<Order>? Orders { get; set; }
        //private ShoppingMethod():this(null!,0)
        //{
           
        //}
        public ShoppingMethod(string name, decimal price, string desc, string t, string b,string c)
        {
            
            Name = name;
            Price = price;
            Description = desc;
            Token = t;
            BaseUrl = b;
            CallBackURL = c;
            Orders = new List<Order>();
        }

        public ShoppingMethod() : this(null!, 0,null!,null!,null!,null!)
        {
           
        }
    }
}

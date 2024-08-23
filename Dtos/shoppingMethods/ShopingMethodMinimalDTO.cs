using System.ComponentModel.DataAnnotations;

namespace Dtos.shoppingMethods
{
    public class ShopingMethodMinimalDTO
    {
       

        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal? Price { get; set; }
        //public List<int> OrderIds { get; set; } = new List<int>();
        public string? Description { get; set; }

        public string? Token { get; set; }


        public string? BaseUrl { get; set; }

        public string? CallBackURL { get; set; }


        public ShopingMethodMinimalDTO(int id, string name, decimal price, string desc, string t, string b, string c)
        {
            Id = id;
            Name = name;
            Price = price;
            Description = desc;
            Token = t;
            BaseUrl = b;
            CallBackURL = c;

        }
        public ShopingMethodMinimalDTO()
        {

        }

    }
}

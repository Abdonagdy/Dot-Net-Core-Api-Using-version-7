using Dtos.Account;
using Dtos.Addresses;
using Dtos.Product;
using Dtos.shoppingMethod;

namespace Dtos.Order
{
    public class OrderDetailsDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Total { get; set; }
        public string? Status { get; set; }

        public decimal? Tax { get; set; }
        public string? Shipping { get; set; }

        public  IEnumerable<ProductMinimalDTO>? Products { get; set; }
        public string? Email { get; set; }

        public string? Fname { get; set; }

        public string? Lname { get; set; }

        public string? UserName { get; set; }
        public string? Country { get; set; }

        public string? City { get; set; }

        public string? Branch { get; set; }
        public string? Phone { get; set; }
        public ShopingMethodMinimalDTO? ShopingMethod { get; set; }

    }
}

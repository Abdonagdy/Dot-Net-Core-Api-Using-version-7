using System.ComponentModel.DataAnnotations.Schema;

namespace Domian
{
    public enum MyStatus { Pending, InProgress, Completed, Cancel }
    public enum MyPaymentStatus { InProgress, }
    [Table("Order")]
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Total { get; set; }
        public string? Status { get; set; }
        public decimal? Tax { get; set; }
        public string? ShippingStaus { get; set; }
        public string? Code { get; set; }
        public string? Email { get; set; }
        public string? Fname { get; set; }
        public string? Lname { get; set; }
        public string? UserName { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? Branch { get; set; }
        public string? Phone { get; set; }

  

        public virtual IEnumerable<OrderDetails> OrderDetails { get; set; }
        public virtual User? User { get; set; }
        public virtual ShoppingMethod ShoppingMethod { get; set; }

        public int? AddressId { get; set; }
        public virtual Address? Address { get; set; }

        public Order(decimal total, decimal tax, string status, string username, string fname, string lname, string country, string city, string branch, string phone, string? shippingStatus, User? user, ShoppingMethod shoppingMethod, Address address, DateTime date)
        {
            Total = total;
            Tax = tax;
            Status = status;
            UserName = username;
            Fname = fname;
            Lname = lname;
            Country = country;
            City = city;
            Branch = branch;
            Phone = phone;
            ShoppingMethod = shoppingMethod;
            Address = address;
            Date = date;
            ShippingStaus = shippingStatus;
            OrderDetails = new List<OrderDetails>();
        }

        public Order() : this(0, 0, null!, null!, null!, null!, null!, null!, null!, null!, null!, null!, null!, null!, DateTime.Now)
        {
        }
    }
}

using Application.Contracts.Orders;
using Domian;
using Dtos.Addresses;
using Dtos.Order;
using Dtos.Product;
using MediatR;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Application.Features.Orders.Queries.GetAllOrderWithDetails
{
    public class GetAllOrderWithDetailsQueryHandler : IRequestHandler<GetAllOrderWithDetailsQuery, IEnumerable<OrderDetailsDTO>>
    {
        private readonly IOrderRepository _orderRepository;

        public GetAllOrderWithDetailsQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<IEnumerable<OrderDetailsDTO>> Handle(GetAllOrderWithDetailsQuery request, CancellationToken cancellationToken)
        {
            var user = await _orderRepository.GetAllOrderWithDetails(request.userid);
           
            if (user == null)
            {
                throw new Exception("Not Found this Order");
            }
            else
            {

                List<OrderDetailsDTO> lo = new List<OrderDetailsDTO>();
                var orders = user.UserAddresses.Select(a => new
                {
                    order=a.Address.Orders.Select(x=>new OrderDetailsDTO
                    {
                        Id = x.Id,
                        Date = x.Date,
                        Status = x.Status,
                        Total = x.Total,
                        Tax=x.Tax,
                        Country=x.Country,
                        City=x.City,
                        Phone=x.Phone,Fname=x.Fname,Lname=x.Lname,Branch=x.Branch,UserName=x.UserName,
                        Shipping=x.ShippingStaus,
                        Products = x.OrderDetails.Select(p => new ProductMinimalDTO
                        {
                            Id = p.Product.Id,
                            Name = p.Product.Name,
                            NameEN = p.Product.NameEN,
                            ServiceCode=p.Product.ServiceCode,
                            Description = p.Product.Description,
                            DescriptionEN=p.Product.DescriptionEN,
                            DiscountPercentage =p.Product.DiscountPercentage,
                            Price = p.Product.Price,
                            Quantity = p.Product.Quantity,
                            Images =p.Product.ImageURL,
                            ShortDescription = p.Product.ShortDescription,
                            ShortDescriptionEN = p.Product.ShortDescriptionEN,
                        })
                    })
                });

                foreach(var item in orders)
                {
                    foreach (var item1 in item.order)
                    {
                    lo.Add(new OrderDetailsDTO
                    {
                        Id = item1.Id,
                        Date = item1.Date,
                        Status = item1.Status,
                        Total = item1.Total,
                        Country = item1.Country,
                        City = item1.City,
                        Phone = item1.Phone,
                        Lname = item1.Lname,
                        Fname = item1.Fname,
                        Email = item1.Email,
                        Branch = item1.Branch,
                        UserName = item1.UserName,
                        Products = item1.Products
                    });

                    }
                }
                
                return lo;
            }

        }
    }
}

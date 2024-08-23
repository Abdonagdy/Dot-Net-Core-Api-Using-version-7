using Application.Contracts.Orders;
using Domian;
using Dtos.Addresses;
using Dtos.Order;
using Dtos.Product;
using Dtos.shoppingMethod;
using MediatR;

namespace Application.Features.Orders.Queries.GetOrderDetails
{
    public class GetOrderDetailsQueryHandler : IRequestHandler<GetOrderDetailsQuery, OrderDetailsDTO>
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrderDetailsQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<OrderDetailsDTO> Handle(GetOrderDetailsQuery request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetDetailsAsync(request.OrderId);
            if (order == null)
            {
                throw new Exception("Not Found this Order");
            }
            else
            {
              
                return new OrderDetailsDTO
                {
                    Id = order.Id,
                    Date = order.Date,
                    Status = order.Status,
                    Total = order.Total,
                    Tax = order.Tax,
                    Shipping=order.ShippingStaus,
                    Country = order.Country,
                    City = order.City,
                    Phone = order.Phone,
                    Lname = order.Lname,
                    Fname = order.Fname,
                    Email = order.Email,
                    Branch = order.Branch,
                    UserName = order.UserName
                    ,
                    ShopingMethod= new ShopingMethodMinimalDTO
                    {
                        Id=order.ShoppingMethod.Id,
                        Name=order.ShoppingMethod!.Name!
                    },
                    Products = order.OrderDetails.Select(x => new ProductMinimalDTO
                    {
                        Id = x.Product.Id,
                        Name = x.Product.Name,
                        NameEN = x.Product.NameEN,
                        DescriptionEN = x.Product.DescriptionEN,
                        Description = x.Product.Description,
                        ServiceCode = x.Product.ServiceCode,
                        DiscountPercentage = x.Product.DiscountPercentage,
                        Price = x.Product.Price,
                        Quantity =order.OrderDetails.Where(a=>a.Order.Id==order.Id).Select(x=>x.Quantity).FirstOrDefault(),
                        Images = x.Product.ImageURL,
                        ShortDescription = x.Product.ShortDescription,
                        ShortDescriptionEN = x.Product.ShortDescriptionEN,
                    })

                };
            }

        }
    }
}

using Application.Contracts;
using Application.Contracts.Addresses;
using Application.Contracts.OrderDetailss;
using Application.Contracts.Orders;
using Application.Contracts.ShoppingMethods;
using DbContextL;
using Domian;
using Dtos.Addresses;
using Dtos.Order;
using Dtos.shoppingMethod;
using Dtos.Users;
using MediatR;
using MimeKit;
using System.Security.Authentication;
using System.Text;

namespace Application.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, OrderMinimalDTO>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOrderDetailsRepository _orderDetailsRepository;
        private readonly IUserRepository _userRepository;
        private readonly IShoppingMethod _shoppingMethod;
        private readonly IAddressRepository _addressRepository;
        private readonly Context _context;

        public CreateOrderCommandHandler(
            IOrderRepository orderRepository,
            IShoppingMethod shoppingMethod, 
            IAddressRepository addressRepository,
            IProductRepository productRepository,
            IOrderDetailsRepository orderDetailsRepository,
            IUserRepository userRepository,
            Context context
            )
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _orderDetailsRepository = orderDetailsRepository;
            _userRepository = userRepository;
            _shoppingMethod = shoppingMethod;
            _addressRepository = addressRepository;
            _context = context;
        }
        
        public async Task<OrderMinimalDTO> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
                try
                {
                    var shoppingMethod = await _shoppingMethod.GetDetailsAsync(request.shoppingmethodId);
                    var address = await _addressRepository.GetDetailsAsync(request.addressId);
                    var user = await _userRepository.GetByIdAsync(request.userId);

                    if (shoppingMethod != null && address != null && user != null)
                    {
                        Order newOrder = await CreateNewOrder(request, user, address, shoppingMethod);

                        // Update points for the user
                        UpdateUserPoints(request, user);

                        // Process order details
                        await ProcessOrderDetails(request, newOrder);

                        // Send notifications
                        SendOrderNotifications(user,newOrder);

                        // Construct and return response DTO
                        return ConstructOrderResponse(newOrder, shoppingMethod);
                    }
                    else
                    {
                        throw new ArgumentNullException("Invalid data received for order creation.");
                    }
                }
                catch (Exception ex)
                {
                   // _logger.LogError(ex, "An error occurred while handling the order creation.");
                   // throw;
                throw new ArgumentException("Invalid code provided for the order.");
            }
            
        }

        private async Task<Order> CreateNewOrder(CreateOrderCommand request, User user, Address address, ShoppingMethod shoppingMethod)
        {

            var bname = _context.branshes.Where(a => a.Braname == address.Region).FirstOrDefault();
            const decimal taxRate = 0.15m;

            //address.Region = bname?.Braname!;
            if (request.Code == null)
            {
                
                Order newOrder = new Order
                {
                    Status = "Pending",
                    Total = request.total,
                    Tax = request.total * (15m / 115m),
                    Date = DateTime.Now,
                    ShoppingMethod = shoppingMethod,
                    User = user,
                    Code = request.Code,
                    ShippingStaus = "الشحن غير مطلوب",
                    Email = user.Email,
                    UserName=user.UserName,
                    Fname=user.Fname,
                    Lname=user.Lname,
                    Country=address.Country,
                    City=address.City,
                    Branch=address.Region,
                    Phone=user.PhoneNumber,
                    Address=address,
                };
                return await _orderRepository.CreateAsync(newOrder);

            }
            else if(request.Code != null)
            {
                var discount = _context.cuponCodes.FirstOrDefault(a => a.Code == request.Code);
                Order newOrder1 = new Order
                {
                    Status = "Pending",
                    Total = request.total - (request.total * discount!.DiscountAmount / (100)),
                    Tax = request.total * (15m / 115m),
                    Date = DateTime.Now,
                    ShoppingMethod = shoppingMethod,
                    User = user,
                    Code = request.Code,
                    ShippingStaus = "الشحن غير مطلوب",
                    Email = user.Email,
                    UserName = user.UserName,
                    Fname = user.Fname,
                    Lname = user.Lname,
                    Country = address.Country,
                    City = address.City,
                    Branch = address.Region,
                    Phone = user.PhoneNumber,

                };
                discount.Isavliable = false;
                _context.SaveChanges();
                return await _orderRepository.CreateAsync(newOrder1);

            }
            return new Order();

        }

        private void UpdateUserPoints(CreateOrderCommand request, User user)
        {
            var point = _context.Points.FirstOrDefault(a => a.UserId == request.userId);
            if (point != null)
            {
                point.Collection += (int)request.total / 10;
                _context.SaveChanges();
            }
        }

        private async Task ProcessOrderDetails(CreateOrderCommand request, Order newOrder)
        {
            foreach (var item in request!.ItemsOfProductListCart!)
            {
                var product = await _productRepository.GetDetailsAsync(item.ProductId);
                if (product != null)
                {
                    product.Quantitytop += item.Quantity;
                    _context.SaveChanges();

                    var orderDetailsTemp = new OrderDetails
                    {
                        Order = newOrder,
                        Product = product,
                        Price = item.Price,
                        Quantity = item.Quantity,
                    };
                    await _orderDetailsRepository.CreateAsync(orderDetailsTemp);
                }
            }
        }

        private void SendOrderNotifications(User user, Order newOrder)
        {
            var bname = _context.branshes.Where(a => a.Braname == newOrder.Branch).FirstOrDefault();
          
            SendSmsReserveConfirmationToCustomer(user!.PhoneNumber!,$"تم تاكيد الطلب الخاص بكم رقم MZ{newOrder.Id}\n ,إجمالى الطلب {newOrder.Total}ريال سعودى\n تاريخ:{newOrder.Date}");

            int i = 1;
            List<string> ccEmails = new List<string>();
            StringBuilder bodySB = new StringBuilder();
            bodySB.Append($"<div dir='rtl'>");
            bodySB.Append($"<p style='color:red'><a href='https://mize.com.sa' dir='rtl'>مراكز مايز لصيانة السيارات</a></p>");
            bodySB.Append($"<p>عزيزى / عزيزتى <b style='color:red'>{user!.UserName}</p>");
            bodySB.Append($"<p>تم تاكيد الطلب الخاص بكم :<span style='color:red'> Mz{newOrder.Id}</span></p>");
            bodySB.Append($"<p>الضريبة :<span style='color:red'>{newOrder.Tax}</span></p>");
            bodySB.Append($"<p>إجمالى الطلب : {newOrder.Total}ريال سعودى</p>");
            bodySB.Append($"<p>تاريخ : {newOrder.Date}</p>");
            bodySB.Append($"<p> طريقة الدفع : {newOrder.ShoppingMethod.Name}</p>");
            bodySB.Append($"<p> الفرع : {bname!.Braname}</p>");
            bodySB.Append($"<p><strong style=' text-align: center;color:red'>الطلب</strong></p>");
            bodySB.Append($"<table style='border:1px solid;text-align:center;'>");
            bodySB.Append("<tr style='background-color:gray;color:white;text-align:center;'><td style='border:1px solid;'>#</td><td style='border:1px solid;'><b>اسم المنتج</b></td><td style='border:1px solid;'><b>كود الخدمة</b></td><td style='border:1px solid;'><b>السعر</b></td><td style='border:1px solid;'><b>الكمية</b></td><td style='border:1px solid;'><b>الإجمالى</b></td></tr>");
            if (newOrder.OrderDetails.Any())
            {
                foreach (var item in newOrder.OrderDetails)
                {
                    bodySB.Append("<tr>");
                    bodySB.Append($"<td style='border:1px solid;'> {i} </td><td style='border:1px solid;'> {item.Product.Name}//{item.Product.NameEN}</td><td style='border:1px solid;'> {item.Product.ServiceCode} </td><td style='border:1px solid;'> {item.Product.Price} </td><td style='border:1px solid;'> {item.Quantity} </td><td style='border:1px solid;'> {item.Quantity * item.Price} </td>");
                    bodySB.Append("</tr>");
                    i++;
                }

            }

            bodySB.Append("</table>");
            bodySB.Append($"</div>");
            //ccEmails.Add("customer.service@mize.sa");
            //  ccEmails.Add("nagdnagdy2017@gmail.com");
            ccEmails.Add("mizeservicecenter@gmail.com");
            ccEmails.Add(bname.Email!);
            SendEmail(user!.Email!, ccEmails, "مراكز مايز لصيانة السيارات", bodySB);
        }

        private OrderMinimalDTO ConstructOrderResponse(Order newOrder, ShoppingMethod shoppingMethod)
        {
           // var bname = _context.branshes.FirstOrDefault(a => a.brannum == int.Parse(newOrder.Address.Region));
            var orderMinimalDTO = new OrderMinimalDTO
            {
                Id = newOrder.Id,
                Date = newOrder.Date,
                Total = newOrder.Total,
                Tax= newOrder.Tax,
                Status = newOrder.Status,
                Address = new AddressMinimalDTO
                {
                    City = newOrder.City!,
                    Region = newOrder.Branch!, // Use branch name if available
                    Country = newOrder.Country!,
                    Email = newOrder.Email!,
                },
                User = new UserMinimalDto
                {
                    FirstName = newOrder.Fname!,
                    LastName = newOrder.Lname!,
                    UserName = newOrder.UserName!
                },
                ShoppingMethod = new ShopingMethodMinimalDTO
                {
                    Id = shoppingMethod.Id,
                    Name = shoppingMethod.Name!,
                    Price = (decimal)shoppingMethod.Price!
                }
          
            };

            return orderMinimalDTO;
        }

        private async void SendEmail(string recipientEmail, List<string> cc, string mailSubject, StringBuilder sb_message)
        {
            var emailToSend = new MimeMessage();
            emailToSend.From.Add(MailboxAddress.Parse("support@mize.com.sa"));
            emailToSend.To.Add(MailboxAddress.Parse(recipientEmail));
            if (cc.Count > 0)
            {
                foreach (var item in cc)
                {
                    if (!string.IsNullOrEmpty(item))
                        emailToSend.Cc.Add(MailboxAddress.Parse(item));
                }
            }

            emailToSend.Subject = mailSubject;
            emailToSend.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = sb_message.ToString()
            };
            //send email
            //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            using (var emailClient = new MailKit.Net.Smtp.SmtpClient())
            {
                emailClient.LocalDomain = "mize.com.sa";
                emailClient.SslProtocols = SslProtocols.Ssl3 | SslProtocols.Tls | SslProtocols.Tls11 | SslProtocols.Tls12 | SslProtocols.Tls13;
                emailClient.CheckCertificateRevocation = false;
                emailClient.Connect("smtppro.zoho.com", 465, true);//587//465
                emailClient.Authenticate("crm@mize.com.sa", "sz5JqvwXAVky");
                await emailClient.SendAsync(emailToSend);
                emailClient.Disconnect(true);

            }

        }

        private void SendSmsReserveConfirmationToCustomer(string cusMobile, string smsBody)
        {
            string url = $"http://mshastra.com/sendurlcomma.aspx?user=20099206&pwd=Mize@388&senderid=20099206&CountryCode=+966&mobileno={cusMobile}&msgtext={smsBody}&smstype=0";
            HttpClient http = new HttpClient();
            http.BaseAddress = new Uri(url);
            http.GetAsync(http.BaseAddress).Wait();
            Task.Delay(5000);
        }
    }
}
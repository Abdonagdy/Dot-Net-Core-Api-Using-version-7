using MediatR;

namespace Application.Features.ShoppingMethods.Commands.UpdateShoppingMethod
{
    public class UpdateShoppingMethodCommand : IRequest<bool>
    {
        public int Id { get; set; }

        public string? Name { get; set; }
        public double? Price { get; set; }

        public string? Description { get; set; }

        public string? Token { get; set; }


        public string? BaseUrl { get; set; }

        public string? CallBackURL { get; set; }
        public UpdateShoppingMethodCommand(string name, double price, string desc, string t, string b, string c)
        {
            // Id = id;
            Name = name;
            Price = price;
            Description = desc;
            Token = t;
            BaseUrl = b;
            CallBackURL = c;
        }
    }
}

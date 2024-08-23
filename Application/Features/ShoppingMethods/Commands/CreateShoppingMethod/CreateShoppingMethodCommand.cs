﻿ 
using Dtos.shoppingMethods;
using MediatR;

namespace Application.Features.ShoppingMethods.Commands.CreateShoppingMethod
{
    public class CreateShoppingMethodCommand:IRequest<ShopingMethodMinimalDTO>
    {
        //public int Id { get; set; }

        public string? Name { get; set; }
        public decimal? Price { get; set; }

        public string? Description { get; set; }

        public string? Token { get; set; }


        public string? BaseUrl { get; set; }

        public string? CallBackURL { get; set; }


        public CreateShoppingMethodCommand(string name, decimal price,string desc , string t, string b,string c)
        {
           // Id = id;
            Name = name;
            Price = price;
            Description = desc;
            Token = t;
            BaseUrl = b;
            CallBackURL= c;
        }
    }
}
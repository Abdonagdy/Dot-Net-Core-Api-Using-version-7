using Dtos.Addresses;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Features.Addesses.Commands.CreateAddress
{
    public class CreateAddressCommand:IRequest<AddressMinimalDTO>
    {
        public int UserId { get; set; }

        [MaxLength(1000), MinLength(1)]
        public string City { get; set; }
        [MaxLength(50), MinLength(1)]
        public string Region { get; set; }
       
        [MaxLength(1000), MinLength(1)]
        public string Country { get; set; }

        [MaxLength(1000), MinLength(1)]
        public string Email { get; set; }
        public CreateAddressCommand() : this(null!, null!, null!,null!)
        {

        }

        public CreateAddressCommand( string city, string region, string country, string e)
        {
            City = city;
            Region = region;
            Country = country;
            Email = e;
        }
    }
}

using Dtos.Addresses;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Features.Addesses.Commands.UpdateAddress
{
    public class UpdateAddressCommand:IRequest<bool>
    {
        public int Id { get; set; }
     
        [MaxLength(100), MinLength(3)]
        public string? City { get; set; }
        [MaxLength(50), MinLength(3)]
        public string? Region { get; set; }
     
        [MaxLength(100), MinLength(5)]
        public string? Country { get; set; }

        [MaxLength(100), MinLength(5)]
        public string? Email { get; set; }
        public UpdateAddressCommand() : this(null!, null!, null!,null!)
        {

        }

        public UpdateAddressCommand( string city, string region, string country, string e)
        {
           
            City = city;
           
           Region = region;
            Country = country;
            Email = e;
        }

    }
}

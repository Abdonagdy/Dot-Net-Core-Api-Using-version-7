using Application.Contracts.Addresses;
using DbContextL;
using Dtos.Addresses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Addesses.Queries.GetAddressDetails
{
    
    public class GetAddressDetailsQueryHandler : IRequestHandler<GetAddressDetailsQuery, AddressMinimalDTO>
    {
        private readonly IAddressRepository _addressRepository;
       
        public GetAddressDetailsQueryHandler(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
            
        }
        public async Task<AddressMinimalDTO> Handle(GetAddressDetailsQuery request, CancellationToken cancellationToken)
        {
            var address = await _addressRepository.GetDetailsAsync(request.Id);
            if (address == null)
            {
                throw new Exception("Not Allowed null Id");
            }

            else
            {
                return new AddressMinimalDTO
                {
                    Id = address.Id,
                    City = address.City,
                    Region = address.Region,
                    Country = address.Country,
                    Email = address.Email,
                  };
            }
                        

            
        }
    }
}

using Application.Contracts.Addresses;
using Application.Contracts.UserAddresses;
using DbContextL;
using Domian;
using Dtos.Addresses;
using MediatR;

namespace Application.Features.Addesses.Commands.CreateAddress
{
    public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommand, AddressMinimalDTO>
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUserAddressesRepository _userAddressesRepository;
        private readonly Context context;

        public CreateAddressCommandHandler(IAddressRepository addressRepository,
            IUserRepository userRepository,
            IUserAddressesRepository userAddressesRepository ,Context _co)
        {
            _addressRepository = addressRepository;
            _userRepository = userRepository;
            _userAddressesRepository = userAddressesRepository;
            context = _co;
        }
        public async Task<AddressMinimalDTO> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
        {
            var user1 = await _userRepository.GetByIdAsync(request.UserId);
            if (user1 == null)
            {
                throw new Exception("not found user");
            }


            Address AddressTemp = new Address()
            {
                City = request.City,
                Region = request.Region,
                Country = request.Country,
                Email = request.Email,
               
                
            };
            var a= context.Address.FirstOrDefault(a=>a.City == AddressTemp.City && a.Country==AddressTemp.Country && a.Email==AddressTemp.Email);
            if (a == null)
            {
                var address = await _addressRepository.CreateAsync(AddressTemp);
                UserAddress userAddress = new UserAddress(user1, address);
                await _userAddressesRepository.CreateAsync(userAddress);
                return new AddressMinimalDTO()
                {
                    Id = address.Id,
                    City = address.City,
                    Region = address.Region,
                    Country = address.Country,
                    Email = address.Email
                };
            }
           else
            {
                return new AddressMinimalDTO()
                {
                    Id = a.Id,
                    City = a.City,
                    Region = a.Region,
                    Country = a.Country,
                    Email = a.Email
                };
            }
            
        }
    }
}

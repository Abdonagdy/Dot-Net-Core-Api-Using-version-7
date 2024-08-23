using Application.Contracts.Addresses;
using DbContextL;
using Dtos.Addresses;
using MediatR;

namespace Application.Features.Addesses.Queries.GetAllAddress
{
    public class GetAllAddressQueryHandler : IRequestHandler<GetAllAddressQuery, IEnumerable<AddressMinimalDTO>>
    {
        private readonly IAddressRepository _addressRepository;
        private readonly Context context;
        public GetAllAddressQueryHandler(IAddressRepository addressRepository, Context _context)
        {
            _addressRepository = addressRepository;
            this.context = _context;

        }
        public async Task<IEnumerable<AddressMinimalDTO>> Handle(GetAllAddressQuery request, CancellationToken cancellationToken)
        {
            var user = context.Users.Where(a=>a.Id==request.UserId).FirstOrDefault();
            return (await _addressRepository.GetAllAddressAsync(request.UserId)).Select(x => 
                new AddressMinimalDTO()
                {
                    Id = x.Id,
                    City = x.City,
                    Region = x.Region,
                    Country =x.Country,
                    Email = x.Email,
                    Fanme=user!.Fname,
                    Lanme=user!.Lname,
                    Phone=user!.PhoneNumber!
                }
            );
        }
    }
}

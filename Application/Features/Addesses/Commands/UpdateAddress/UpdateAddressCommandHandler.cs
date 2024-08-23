using Application.Contracts.Addresses;
using Domian;
using MediatR;
using System.Diagnostics.Metrics;

namespace Application.Features.Addesses.Commands.UpdateAddress
{
    public class UpdateAddressCommandHandler : IRequestHandler<UpdateAddressCommand, bool>
    {
        private readonly IAddressRepository _addressRepository;

        public UpdateAddressCommandHandler(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }
        public async Task<bool> Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
        {
            var address = await _addressRepository.GetDetailsAsync(request.Id);
            if (address == null)
            {
                return false;
            }
            else
            {
                 if (request.City != null)
                     address.City = request.City;
                if (request.Region != null)
                     address.Region = request.Region;
                if (request.Country != null)
                    address.Country = request.Country;
                if (request.Email != null)
                    address.Email = request.Email;

                return await _addressRepository.UpdateAsync(address);
            }
        }
    }
}

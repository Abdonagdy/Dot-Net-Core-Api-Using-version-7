using Application.Contracts.Addresses;
using DbContextL;
using Domian;
using Microsoft.EntityFrameworkCore;

namespace InfraStructure.Addresses
{
    public class AddressRepository : Repository<Address, int>,IAddressRepository
    {
        public AddressRepository(Context context) : base(context)
        {
        }

        public async Task<IEnumerable<Address>> GetAllAddressAsync(int id)
        {
            try
            {
                var user = await _context.Users
                    .Include(x => x.UserAddresses)
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (user == null)
                {
                    throw new ArgumentException("User not found");
                }

                if (user.UserAddresses == null || !user.UserAddresses.Any())
                {
                    // Handle the case where the user has no associated addresses
                    return new List<Address>();
                }

                var allAddresses = await _context.Address.ToListAsync(); // Fetch all addresses

                if (allAddresses == null || !allAddresses.Any())
                {
                    throw new Exception("No addresses found in the database");
                }

                List<Address> addresses = new List<Address>();

                foreach (var userAddress in user.UserAddresses)
                {
                    if (userAddress.Address != null && userAddress.Address.Id != null)
                    {
                        var matchingAddress = allAddresses.FirstOrDefault(a => a.Id == userAddress.Address.Id);

                        if (matchingAddress != null)
                        {
                            addresses.Add(matchingAddress);
                        }
                        else
                        {
                            // Log the issue if the address is not found
                            // For example: _logger.LogWarning($"Address with ID {userAddress.Address.Id} not found");
                        }
                    }
                    else
                    {
                        // Log or handle the case where the address or its ID is null
                        // For example: _logger.LogWarning("Null address or address ID encountered");
                    }
                }

                return addresses;
            }
            catch (ArgumentException ex)
            {
                // Log or handle the case where the user is not found
                // For example: _logger.LogError("User not found", ex);
                throw; // Rethrow the exception for higher-level handling
            }
            catch (Exception ex)
            {
                // Log or handle other exceptions
                // For example: _logger.LogError("An error occurred while fetching addresses", ex);
                throw; // Rethrow the exception for higher-level handling
            }
        }    
    }
}

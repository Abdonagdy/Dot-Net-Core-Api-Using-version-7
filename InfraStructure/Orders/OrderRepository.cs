using Application.Contracts.Orders;
using DbContextL;
using Domian;
using Microsoft.EntityFrameworkCore;

namespace InfraStructure.Orders
{
    public class OrderRepository : Repository<Order, int>, IOrderRepository
    {
        public OrderRepository(Context context) : base(context)
        {
        }

        public async Task<IEnumerable<Order>> GetAllOrdersForAUserAsync(int userId)
        {
            try
            {
                //var userwithOrders = await _context.Users
                //               //.Include(a => a.UserAddresses)!
                //               //.ThenInclude(u => u.Address)
                //               .ThenInclude(o => o.Orders)
                //               .FirstOrDefaultAsync(x => x.Id == userId);
                //if (userwithOrders != null)
                //{
                //    return userwithOrders.UserAddresses!
                //   .Select(a => a.Address)
                //   .SelectMany(o => o.Orders!);
                //}
                //else
                //{
                //  
                //}

                var order = await _context.Orders.Where(a =>a.User.Id == userId).ToListAsync();
                if(order != null)
                {
                    return order;
                }
                else
                {
                    throw new Exception("Not Found User");
                }
                

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }



        }

       

        public async override Task<Order?> GetDetailsAsync(int id)
        {
            return await _context.Orders.Include(a=>a.ShoppingMethod)
                .Include(o => o.OrderDetails)
                .ThenInclude(p => p.Product)
                .Include(o => o.Address)
                .FirstOrDefaultAsync(o => o.Id == id);


        }

        public async Task<User?> GetAllOrderWithDetails(int userid)
        {

            return await _context.Users
                .Include(o => o.UserAddresses)
                .ThenInclude(u => u.Address)
                .ThenInclude(o => o.Orders)
                .ThenInclude(o => o.OrderDetails)
                .ThenInclude(p => p.Product)
                .FirstOrDefaultAsync(o => o.Id == userid);



        }
    }
}

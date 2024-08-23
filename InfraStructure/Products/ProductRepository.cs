using Application.Contracts;
using DbContextL;
using Domian;
using Microsoft.EntityFrameworkCore;

namespace InfraStructure
{
    public class ProductRepository : Repository<Product, long>, IProductRepository
    {

        public ProductRepository(Context context) : base(context)
        {

        }
      
        public Task<IEnumerable<Product>> FilterByAsync(string? filter = null, int? fromPrice = null, int? toPric = null, bool? IsAvailable = null, bool? hasDiscount = null, int? categoryId = null)
        {

            IEnumerable<Product> FilterProductsQuery =
                _context.Products.Include(a=>a.Categories)
                .Where(a => filter == null || a.Name!.ToLower().Contains(filter.ToLower()) || (a.Description != null && a.Description.ToLower().Contains(filter.ToLower())))
                .Where(a => fromPrice == null || a.Price >= fromPrice)
                .Where(a => toPric == null || a.Price <= toPric)
                .Where(a => IsAvailable == null || a.Quantity > 0)
                .Where(a => hasDiscount == null || a.DiscountPercentage != null)
                .Where(a => categoryId == null || a.Categories.Any(b => b.Id == categoryId));

            return Task.FromResult(FilterProductsQuery);

        }
        public override async Task<Product?> GetDetailsAsync(long id)
        {
                var product = await _context.Products
                .Include(a => a.Categories).Include(b => b.Articals)
                .FirstOrDefaultAsync(a => a.Id == id);
   
            return   product;
        }
    }
}

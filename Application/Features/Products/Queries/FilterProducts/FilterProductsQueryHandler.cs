using Application.Contracts;
using MediatR;
using Dtos.Category;
using Dtos.Product;
using Application.Features.Products.Queries.GetAllProducts;
using DbContextL;
using Domian;

namespace Application.Features.Products.Queries.GetAllProducts
{
    public class FilterProductsQueryHandler:IRequestHandler<FilterProductsQuery, IEnumerable<ProductMinimalDTO>>
    {
        private readonly IProductRepository _productRepository;
        private readonly Context context;
        public FilterProductsQueryHandler(IProductRepository productRepository,Context _context)
        {
            _productRepository = productRepository;
            context = _context;
        }
        public async Task<IEnumerable<ProductMinimalDTO>> Handle(FilterProductsQuery request, CancellationToken cancellationToken)
        {
             
            return (await _productRepository.FilterByAsync(request.filter, request.price, request.Toprice, request.Isavailable, request.HasDiscount, request.categoryId))
                  .Select(c => new ProductMinimalDTO()
                  {
                      Id = c.Id,
                      Name = c.Name,
                      NameEN = c.NameEN,
                      Description = c.Description,
                      DescriptionEN = c.DescriptionEN,ServiceCode=c.ServiceCode,
                      OldPrice = c.OldPrice,
                      Price = c.Price,
                      Quantity = c.Quantity,
                      DiscountPercentage = c.DiscountPercentage,
                      ShortDescription = c.ShortDescription,
                      ShortDescriptionEN = c.ShortDescriptionEN,
                      Images = c.ImageURL,
                      SeName = c.SeName,
                      MetaTitle = c.MetaTitle,
                      MetaKeywords = c.MetaKeywords,
                      MetaDescription = c.MetaDescription,
                      CategoriesNames=c.Categories.Select(c=>c.Id).ToList(),
                      CategoriesNames1 = c.Categories.Select(c => c.Name).ToList(),
                      CategoryName= c.Categories.Select(c => c.Name).FirstOrDefault()



                  });
  
        }


    }
}

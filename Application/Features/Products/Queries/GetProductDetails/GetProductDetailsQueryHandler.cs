using Application.Contracts;
using MediatR;
using Dtos.Product;

 

namespace Application.Features.Products.Queries.GetProductDetails
{
    public class GetProductDetailsQueryHandler : IRequestHandler<GetProductDetailsQuery,ProductLargeDto>
    {
        private readonly IProductRepository _productRepository;

        public GetProductDetailsQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<ProductLargeDto> Handle(GetProductDetailsQuery request, CancellationToken cancellationToken)
        {
            var product =await _productRepository.GetDetailsAsync(request.Id);

            if (product == null)
            {
                throw new Exception($"NO Product with This Id {request.Id}");
            }

            else
            {
                ProductLargeDto p = new ProductLargeDto
                {
                        Id = product.Id,
                        Name = product.Name,
                        NameEN = product.NameEN,
                        Description = product.Description,
                        DescriptionEN = product.DescriptionEN,
                        DiscountPercentage= product.DiscountPercentage,
                        OldPrice = product.OldPrice,
                        Price = product.Price,
                        ServiceCode = product.ServiceCode,
                        Quantity = product.Quantity,
                        Images=product.ImageURL,
                        SeName=product.SeName,
                        MetaTitle=product.MetaTitle,
                        MetaKeywords=product.MetaKeywords,
                        MetaDescription=product.MetaDescription,
                       // CategoryId=product.CategoryId    ,
                        ShortDescription=product.ShortDescription,
                        ShortDescriptionEN=product.ShortDescriptionEN,
                        Articals   =product.Articals,
                        CategoryName=product.Categories.Select(c => c.Name).FirstOrDefault(),
                };
                foreach (var item in product.Categories)
                {
                    p.CategoriesNames.Add(item.Id);

                }
                
                return p;     
            }
        }

    }
}

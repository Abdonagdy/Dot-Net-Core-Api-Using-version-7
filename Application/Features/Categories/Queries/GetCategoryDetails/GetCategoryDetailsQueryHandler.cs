using Application.Contracts;
using MediatR;
using Dtos.Category;
using Dtos.Product;
using Domian;
using System.Linq;

namespace Application.Features.Categories.Queries.GetCategoryDetails
{
    public class GetCategoryDetailsQueryHandler : IRequestHandler<GetCategoryDetailsQuery, CategoryDetailsDto>
    {
        private readonly ICategoryRepository _categoryRepository;
    

        public GetCategoryDetailsQueryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
           
        }

        public async Task<CategoryDetailsDto> Handle(GetCategoryDetailsQuery request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetDetailsAsync(request.Id);
            if (category == null)
            {
                throw new Exception($"NO Category with This Id {request.Id}");
            }

            else
            {

                CategoryDetailsDto catDto = new CategoryDetailsDto
                {
                    Id = category.Id,
                    Name = category.Name,
                    NameEN = category.NameEN,
                    SeName = category.SeName,
                    MetaTitle = category.MetaTitle,
                    MetaKeywords = category.MetaKeywords,
                    MetaDescription = category.MetaDescription,
                    productMinimalDtos = category.Products.Select(a =>
                    new ProductMinimalDTO
                    {
                        Id = a.Id,
                        Name = a.Name,
                        NameEN=a.NameEN,
                        DescriptionEN=a.DescriptionEN,
                        Description = a.Description,
                        DiscountPercentage = a.DiscountPercentage,
                        Price = a.Price,
                        Quantity = a.Quantity,
                        Images = a.ImageURL,
                        ShortDescription = a.ShortDescription,
                        ShortDescriptionEN= a.ShortDescriptionEN,
                    })                
                };


                return catDto;
            }
        }
    }
}
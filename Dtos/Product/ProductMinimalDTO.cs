using System.ComponentModel.DataAnnotations;

namespace Dtos.Product
{
    public class ProductMinimalDTO
    {
        public long Id { get; set; }
        [MinLength(3), MaxLength(200)]
        public string? Name { get; set; }


        [MinLength(3), MaxLength(200)]
        public string? NameEN { get; set; }
        public string? DescriptionEN { get; set; }

        //  [MinLength(5), MaxLength(500)]
        public string? Description { get; set; }
     
        [Range(0, 100)]
        public int? DiscountPercentage { get; set; }
        public decimal? OldPrice { get; set; }

        public decimal Price { get; set; }

        public string? ServiceCode { get; set; }

        [Range(0, 50)]
        public int Quantity { get; set; }
        public string? Images { get; set; }

       public string?  ShortDescription { get; set; }
        public string? ShortDescriptionEN { get; set; }
        public List<int> CategoriesNames { get; set; } = new List<int>();
        public List<string> CategoriesNames1 { get; set; } = new List<string>();
        public string? MetaKeywords { get; set; }

        public string? MetaDescription { get; set; }

        public string? MetaTitle { get; set; }

        public string? SeName { get; set; }

        public string? CategoryName { get; set; }
    }
}

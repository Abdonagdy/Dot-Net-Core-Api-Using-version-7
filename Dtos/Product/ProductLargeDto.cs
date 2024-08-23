using Domian;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.Product
{
    public class ProductLargeDto
    {
        public long Id { get; set; }

        [MinLength(3), MaxLength(200)]
        public string? Name { get; set; }
    
       // [MinLength(5), MaxLength(500)]
        public string? Description { get; set; }
        [MinLength(3), MaxLength(200)]
        public string? NameEN { get; set; }
        public string? DescriptionEN { get; set; }

        [Range(0, 100)]
        public int? DiscountPercentage { get; set; }
        public decimal? OldPrice { get; set; }

        public decimal Price { get; set; }

        public string? ServiceCode { get; set; }
        [Range(0, 50)]
        public int Quantity { get; set; }
        public List<int> CategoriesNames { get; set; } = new List<int>();
        public string? Images { get; set; }
        public string? ShortDescription { get; set; }
        public string? ShortDescriptionEN { get; set; }

        public string? MetaKeywords { get; set; }

        public string? MetaDescription { get; set; }

        public string? MetaTitle { get; set; }

        public string? SeName { get; set; }
        

        public string? CategoryName { get; set; }   
        public IEnumerable<Domian.Artical>? Articals { get; set; }
    }
 
}

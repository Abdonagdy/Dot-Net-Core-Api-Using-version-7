using Dtos.Product;
using System.ComponentModel.DataAnnotations;

namespace Dtos.Category
{
    public class CategoryMinimalDTO
    {
        public int Id { get; set; }
        [MinLength(3), MaxLength(200)]
        public string Name { get; set; }

        [MinLength(3), MaxLength(200)]
        public string NameEN { get; set; }

        public string  ImageUrl { get; set; }
        public string? MetaKeywords { get; set; }

        public string? MetaDescription { get; set; }

        public string? MetaTitle { get; set; }

        public string? SeName { get; set; }


        public List<long>? Products { get; set; }= new List<long>();
    }
}

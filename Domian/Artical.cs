using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domian
{
    public class Artical
    {
      

        [Key]
        public int ArticalId { get; set; }

        public string? ArticalName { get; set;}

        public string? ArticalTitle { get; set;}

        
        public string? ArticalDescription { get; set;}

        [Display(Name = "MetaKeywords")]
        public string? MetaKeywords { get; set; }
        [Display(Name = "MetaDescription")]
        public string? MetaDescription { get; set; }
        [Display(Name = "MetaTitle")]
        public string? MetaTitle { get; set; }
        [Display(Name = "SeName")]
        public string? SeName { get; set; }

        private IFormFile? imagesFile;
        public string? ImageURL { get; set; }

        public string Date {get; set;}
        public ICollection<Comment>? Comments { get; set; }


        [ForeignKey("Product")]
        public long? ProductId { get; set; }
        public Product? Product { get; set; }

        public Artical(string name , string title, string description ,string url, string mk , string mt,string md , string sn, long product)
        {
            ArticalName = name;
            ArticalTitle = title;
            ArticalDescription = description;
            MetaDescription=md;
            MetaKeywords=mk;
            MetaTitle=mt;
            SeName = sn;
            Comments = new List<Comment>();
            ImageURL= url;
            Date = DateTime.Now.Day.ToString() + DateTime.Now.ToString("MMM");
            ProductId = product;
        }
        public Artical():this(null!,null!,null!,null!,null!, null!, null!, null!,0) { }
    }
}

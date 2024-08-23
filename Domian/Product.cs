using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domian
{
    [Table("Product")]
    public class Product
    {
        public long Id { get; set; }
        [MinLength(3), MaxLength(200)]
        public string? Name { get; set; }
        //Globalization
        //Globalization
        [MinLength(3), MaxLength(200)]
        public string? NameEN { get; set; }
        public string? DescriptionEN { get; set; }
        //Globalization
        public string? Description { get; set; }
        //Globalization
        [Range(0, 100)]
        public int? DiscountPercentage { get; set; }

        public decimal? OldPrice { get; set; }


        public decimal Price { get; set; }
        
        public int Quantity { get; set; }

        public int? Quantitytop { get; set; }


        public string? ServiceCode { get; set; }

        public string ImageURL { get; set; }

        public string? ShortDescription { get; set; }
        public string? ShortDescriptionEN { get; set; }

        public string? MetaKeywords { get; set; }

        public string? MetaDescription { get; set; }

        public string? MetaTitle { get; set; }

        public string? SeName { get; set; }

        public ICollection<Price>? PriceList { get; set; }
        //private IList<Category> categories;
        public ICollection<Category> Categories { get; set; }

        //relation with Wishlist
        public virtual IEnumerable<WishList>? WishLists { get; set; }

        public virtual IEnumerable<Artical>? Articals { get; set; }

        public Product(string name,string ne,decimal oldprice, decimal price,string servicecode,string shotrd,string mk, string mt, string md, string sn, string shen ,string img,Category category, string? description = null,string? de=null, int? discountPercentage = null)
        {
            Name = name;
            NameEN= de;
            DescriptionEN= ne;
            Categories = new List<Category>();
            Description = description;
            DiscountPercentage = discountPercentage;
            OldPrice = oldprice;
            Price = price;
            ServiceCode = servicecode;
            MetaDescription = md;
            MetaKeywords = mk;
            MetaTitle = mt;
            SeName = sn;
            ImageURL = img;
            ShortDescription = shotrd;
            ShortDescriptionEN = shen;
           // Categories = category;
            WishLists = new List<WishList>();
            Articals = new List<Artical>();

        }

        public Product() : this(null!,null!,0, 0, null!,null!, null!, null!, null!, null!, null!,null!,null!, null!, null!,null!) { }

    }
}
﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domian
{
    [Table("Category")]
    public class Category
    {
        public int Id { get; set; }
        [MinLength(3), MaxLength(200)]
        public string Name { get; set; }


        [MinLength(3), MaxLength(200)]
        public string NameEN { get; set; }

        public string ImageURL { get; set; }

        public string? MetaKeywords { get; set; }

        public string? MetaDescription { get; set; }

        public string? MetaTitle { get; set; }

        public string? SeName { get; set; }
        //selfRelation

        public Category? Parentcategory { get; set; }

        //private IList<Category> subCategories;
        public IEnumerable<Category> SubCategories { get; set; }

        //Relation for Product
        //private readonly IList<Product> products;
        public IEnumerable<Product> Products { get; set; }

        
        public Category(string name, string mk, string mt, string md, string sn, Category? parentcategory)
        {
            Name = name;
            MetaDescription = md;
            MetaKeywords = mk;
            MetaTitle = mt;
            SeName = sn;
            Parentcategory = parentcategory;
            SubCategories = new List<Category>();
            Products = new List<Product>();



        }
        public Category() : this(null!, null!, null!, null!, null!, null!) { }

        //public bool AddSubCategory(Category SubCategory)
        //{
        //    var ISCategoryNull = SubCategories.FirstOrDefault(x => x.Name == SubCategory.Name);
        //    if (ISCategoryNull == null)
        //    {
        //        subCategories.Add(SubCategory);
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
        //public bool AddProduct(Product product)
        //{
        //    var ISProductNull = products.FirstOrDefault(x => x.Name == product.Name);
        //    if (ISProductNull == null)
        //    {
        //        products.Add(product);
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
    }
}

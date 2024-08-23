using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domian
{
    public class KemiaOrder
    {
        public int id { get; set; }
        [Display(Name = "الوصف")]
        public string? Desc { get; set; }

        [Display(Name = "الكمبة")]

        //[Display(Name = "الكمية")]
        public int? kem { get; set; }

        //[Display(Name = "السعر")]
        public string? Item { get; set; }
        public double? Unitprice { get; set; }
        public double price { get; set; }
        //[Display(Name = "الاجمالى")]

        public double res { get; set; }

        [ForeignKey("PurshesOrder")]
        public int? mizeNum { get; set; }
        public virtual PurseOrder? PurshesOrder { get; set; }

      
        public KemiaOrder(string? des, int? k,int mn)
        {
            Desc = des;
            kem = k;
            Item = string.Empty;
            Unitprice = 0;
            price =0.0;
            res = 0.0;
            mizeNum = mn;

        }
     

        public KemiaOrder(): this(null!, null!, 0) { }

        

    }

}

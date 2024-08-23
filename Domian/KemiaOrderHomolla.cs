using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domian
{
    public class KemiaOrderHomolla
    {
        public int id { get; set; }
        [Display(Name = "الوصف")]
        public string? Desc { get; set; }

        [Display(Name = "الكمبة")]

        //[Display(Name = "الكمية")]
        public int? kem { get; set; }

        //[Display(Name = "السعر")]
        public double price { get; set; }
        //[Display(Name = "الاجمالى")]

        public double ManualWork { get; set; }

        public double res { get; set; }

       
        public int? mizeNum { get; set; }
        public virtual PurseOrderHomalla? PurshesOrder { get; set; }

        
        public KemiaOrderHomolla(string? des, int? k, int? mn )
        {
            Desc = des;
            kem = k;
            price =0.0;
            ManualWork = 0.0;
            res = 0.0;
            mizeNum = mn;

        }
     

        public KemiaOrderHomolla(): this(null!, null!, null!) { }

        

    }

}

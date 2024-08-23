using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domian
{
    public class CuponCode
    {
        public int Id { get; set; }
        public string? Code { get; set; }
        public decimal DiscountAmount { get; set; }

        public bool Isavliable { get; set; }
        public DateTime ExpirationDate { get; set; }


        public CuponCode(string? code,decimal disc,bool i, DateTime d )
        {
            Code = code;
            DiscountAmount = disc;
            Isavliable = i;
            ExpirationDate = d;
        }

        public CuponCode():this(null!,0,true, DateTime.Now)
        {

        }
    }
}

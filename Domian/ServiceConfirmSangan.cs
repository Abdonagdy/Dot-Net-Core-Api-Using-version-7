using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domian
{
    public class ServiceConfirmSangan
    {
        public int id { get; set; }

        public string Name { get; set; }


        [ForeignKey("ConfirmSangan")]
        public int? ConfirmSanganid { get; set; }
        public ConfirmSangan? ConfirmSangan { get; set; }

        public ICollection<PriceConfirmShangan>? Prices { get; set; }


        public ServiceConfirmSangan(string n,int c)
        {

            Name = n;
            ConfirmSanganid = c;
            Prices = new List<PriceConfirmShangan>();
        }

        public ServiceConfirmSangan() : this(null!, 0) { }
    }
}

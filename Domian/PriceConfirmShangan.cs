using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domian
{
    public class PriceConfirmShangan
    {
        public int id { get; set; }


        public string name { get; set; }
        public decimal? price { get; set; }



        [ForeignKey("CarService")]
        public int? CarServiceId { get; set; }
        public ServiceConfirmSangan? CarService { get; set; }
        public PriceConfirmShangan(string n, decimal p, int c)
        {

            name = n;
            price = p;
            CarServiceId = c;
        }

        public PriceConfirmShangan() : this(null!, 0, 0) { }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domian
{
    public class CarService
    {
        public int id { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }
        public ICollection<Price> Prices { get; set; }


        [ForeignKey("CarName")]
        public int? carnameId { get; set; }
        public CarNamesh? CarName { get; set; }


        [ForeignKey("disService")]
        public int? disServiceId { get; set; }
        public DisstanceService? disService { get; set; }

      

        public CarService(string n ,string d , int c , int dd) {
        
            Name = n;
            Description = d;
            carnameId = c;
            disServiceId = dd;
        
            Prices= new List<Price>();
        }

        public CarService():this(null!,null!,0,0) { }
    }
}

using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domian
{
    public class DisstanceService
    {

        public int id { get; set; }
        public string name { get; set; }

        public ICollection<CarService> cars { get; set; }

         public DisstanceService(string n) {
        
        
           name = n;
           cars = new List<CarService>();
        }

        public DisstanceService():this(null!) { }
    }
}

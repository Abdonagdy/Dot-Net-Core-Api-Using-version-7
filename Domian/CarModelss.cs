using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domian
{
    public class CarModelss
    {

        public int id { get; set; }

        public string Name { get; set; }

      
        public ICollection<CarNamesh> CarName { get; set; }
        public CarModelss(string n ) {
        
            Name = n;
             CarName = new List<CarNamesh>();
        }

        public CarModelss():this(null!) { }
    }
}

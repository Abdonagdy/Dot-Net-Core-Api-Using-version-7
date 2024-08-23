using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domian
{
    public class Madina
    {
        public int id { get; set; }

        public string CityName { get; set; }


        public ICollection<Bransh> Madins { get; set; }


    

        public Madina(string m) {
        
            CityName = m;
      
            Madins = new List<Bransh>();
        }

        public Madina():this(null!) { }
    }
}

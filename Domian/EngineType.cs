using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domian
{
    public class EngineType
    {
        public int id { get; set; }

        public string name { get; set; }

        [ForeignKey("ModelYearCar")]
        public int ModelYearCarid { get; set; }
        public ModelYearCar ModelYearCar { get; set; }

          public EngineType(string n,int m ) {
        
                name = n;
                ModelYearCarid = m;
        
        }

        public EngineType():this(null!,0) { }
    }
}

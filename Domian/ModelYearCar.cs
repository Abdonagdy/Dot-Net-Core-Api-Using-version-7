using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domian
{
    public class ModelYearCar
    {
        public int id { get; set; }

        public string YearNname { get; set; }

        [ForeignKey("carName")]
        public int carid { get; set; }
        public CarNamesh carName { get; set; }

         public ICollection<EngineType> engine { get; set; }

        public ModelYearCar(string y) {
        
            YearNname = y;
            engine = new List<EngineType>();
        }

        public ModelYearCar():this(null!) { }
    }
}

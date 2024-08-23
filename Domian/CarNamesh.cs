using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domian
{
    public class CarNamesh
    {
        public int id { get; set; }

        public string Name { get; set; }


        [ForeignKey("carModel")]
        public int? carModelid { get; set; }
        public CarModelss? carModel { get; set; }

        
        public ICollection<ModelYearCar>?  modelYears {get; set; }  
        
        public ICollection<CarService>? carServices { get; set; }
        public CarNamesh(string n , int car , int c ) { 
            Name = n;
            carModelid = car;
             carServices = new List<CarService>();
            modelYears= new List<ModelYearCar>();
        }
        public CarNamesh():this(null!,0,0)
        {
            

        }
    }
}

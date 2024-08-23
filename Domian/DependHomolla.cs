using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domian
{
    public class DependHomolla
    {
        public int id { get; set; }

        public Boolean IsDepend { get; set; }

        [ForeignKey("PurseOrder")]
        public int? PrId { get; set; }
        public virtual PurseOrderHomalla? PurseOrder { get; set; }


        public DependHomolla(Boolean isd ,int p ) {
        
         IsDepend = isd;
         PrId = p;
        
        }

        public DependHomolla():this(false,0) { }
    }
}

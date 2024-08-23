using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domian
{
    public class Depend
    {
        public int id { get; set; }

        public Boolean IsDepend { get; set; }

        [ForeignKey("PurseOrder")]
        public int? PrId { get; set; }
        public virtual PurseOrder? PurseOrder { get; set; }


        public Depend(Boolean isd ,int p ) {
        
         IsDepend = isd;
         PrId = p;
        
        }

        public Depend():this(false,0) { }
    }
}

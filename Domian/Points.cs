using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domian
{
    public class Points
    {
        public int Id { get; set; }

        public int Collection { get; set; }

        [ForeignKey("user")]
        public int? UserId { get; set; }
        public User? user { get; set; }

        public Points(int p , int u) {

            Collection = p;
            UserId = u;
        
        }

        public Points() { }
    }
}

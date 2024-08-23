using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domian
{
    public class BranchService
    {
        public int id { get; set; }

        public string? Descrption { get; set; }


        [ForeignKey("Bransh")]
        public long? BranchId { get; set; }

        public Bransh? Bransh { get; set; }


        public BranchService(string d , int b) {
        
            Descrption = d;
            BranchId = b;
        
        }

        public BranchService():this(null!,0) { }
    }
}

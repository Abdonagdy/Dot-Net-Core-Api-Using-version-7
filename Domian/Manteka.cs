using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domian
{
    public class Manteka
    {
        public int id { get; set; }

        [Display(Name = "Name")]
        public string? Name { get; set; }

        public ICollection<Bransh>? Branshes { get; set; }

        public Manteka(string n) {
        
          Name = n;
          Branshes = new List<Bransh>();
        
        }

        public Manteka():this(null!) { }
    }
}

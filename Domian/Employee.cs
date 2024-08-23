using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domian
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public long EmpNum { get; set; }

        [Required]
        public string EmpName { get; set; }

        public string? BranceName { get; set; }

        public string? EmpJob { get; set; }

        [ForeignKey("Bransh")]
        public long? braId { get; set; }
        public virtual Bransh? Bransh { get; set; }


        public IEnumerable<Response>? Responses { get; set; }

    }
}

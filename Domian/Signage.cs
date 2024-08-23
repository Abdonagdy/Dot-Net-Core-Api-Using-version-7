using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domian
{
    public class Signage
    {
         public int Id { get; set; } // int
         public string SignageUrl { get; set; } // nvarchar(max)
         public int? Duration { get; set; } // int
         public bool IsActive { get; set; } // bit
         public int? DisplayOrder { get; set; } // int
    }
}

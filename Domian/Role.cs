using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domian
{
    [Table("Role")]
    public class Role : IdentityRole<int>
    {

       
        public virtual IEnumerable<User>? Users { get; set; }

       
    }
}

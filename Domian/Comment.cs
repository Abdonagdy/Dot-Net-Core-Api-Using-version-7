using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domian
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }

        public string? Commentt { get; set; }

        public DateTime? Date { get; set; }

        public string  UserName { get; set; }

        public bool Show { get; set; }

        [ForeignKey("Artical")]
        public int ArticalId { get; set; }

        public virtual Artical? Artical { get; set; }



        public Comment(string comment , int artical, string user)
        {
            Commentt = comment;
            UserName =user;
            ArticalId = artical;
            Date = DateTime.Now;
        }

        public Comment():this(null!,0, null!) { }

    }
}

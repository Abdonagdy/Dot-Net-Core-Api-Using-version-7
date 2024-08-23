using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Domian
{
    public class Homollamoward
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string mordnum { get; set; }
        public string mordname { get; set;}


        [ForeignKey("User")]
        public int? UserID { get; set; }
        public virtual User? User { get; set; }

        public Homollamoward(string num , string n , int? u)
        {
            mordnum = num;
            mordname = n;
            UserID = u;
        }

        public Homollamoward():this(null!,null!,0)
        { }
    }
}
